function init() {
    var input = $("#UnKVoc");
    var suggestions = $("#suggestions");

    input.on("input", function () {
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
                            var suggestionList = $("#suggestion-list");
                            suggestionList.empty();
                            if (data.length > 0) {
                                suggestionList.append("<div class='suggestion'>" + data[0] + "</div>");
                                suggestions.show();
                            }
                            else {
                                suggestions.hide();
                            }
                        }
                    });
                } else {
                    suggestions.hide();
                }
            }
        });
    });

    suggestions.on("click", ".suggestion", function () {
        var suggestion = $(this).text();
        $("#KVoc").val(suggestion);
        suggestions.hide();
    });

    input.blur(function () {
        suggestions.hide();
    });
}
