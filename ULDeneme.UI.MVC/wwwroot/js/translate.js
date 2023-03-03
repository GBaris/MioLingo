namespace ULDeneme.UI.MVC.wwwroot.js
{
    public class translate
    {
        $(document).ready(function() {
            var input = $("#UnKVoc");
            var suggestions = $("#suggestions");

            input.keyup(function () {
                var text = input.val();
                var fromLang = "@ViewBag.KnownLangShort";
                var toLang = "@ViewBag.UnknownLangShort";

                $.ajax({
                    type: "POST",
                    url: "/Translation/Translate",
                    data: { textToTranslate: text, fromLang: fromLang, toLang: toLang },
                    success: function (data) {
                        var words = data.split(" ");
                        var lastWord = words[words.length - 1];
                        if (lastWord.length > 2) {
                            $.ajax({
                                type: "POST",
                                url: "/Translation/Suggest",
                                data: { word: lastWord, fromLang: fromLang, toLang: toLang },
                                success: function (data) {
                                    suggestions.empty();
                                    for (var i = 0; i < data.length; i++) {
                                        suggestions.append("<div>" + data[i] + "</div>");
                                    }
                                }
                            });
                        } else {
                            suggestions.empty();
                        }
                    }
                });
            });
        });
    }
}
