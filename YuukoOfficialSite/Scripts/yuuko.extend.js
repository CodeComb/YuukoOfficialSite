function NavFix()
{
    $(".yuuko-nav-item.active").unbind().each(function () {
        $(".yuuko-nav-hide").remove();
		var pos = $(this).offset();
		$("body").prepend("<div class='yuuko-nav-hide'></div>");
		$(".yuuko-nav-hide").css("top", pos.top + $(this).outerHeight() - 2);
		$(".yuuko-nav-hide").css("left", pos.left);
		$(".yuuko-nav-hide").width($(this).outerWidth() - 1);
	});
}

window.onresize = function () {
	NavFix();
};

function ToggleLog(id)
{
    $(id).toggle();
}

$(document).ready(function () {
    var disqus_shortname = 'yuuko';
    (function () {
        var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
        dsq.src = '//' + disqus_shortname + '.disqus.com/embed.js';
        (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
    })();

    NavFix();
    DetailEvents.SamplePort.onEditing = function () {
        $("#summary").val(CKEDITOR.instances.summary.getData());
        $("#content").val(CKEDITOR.instances.content.getData());
    };
    DetailEvents.SamplePort.onInserting = function () {
        $("#summary").val(CKEDITOR.instances.summary.getData());
        $("#content").val(CKEDITOR.instances.content.getData());
    };
    DetailEvents.SamplePort.onLoaded = function () {
        CKEDITOR.replace("summary");
        CKEDITOR.replace("content");
    };
    DetailEvents.LogPort.onLoaded = function () {
        CKEDITOR.replace("content");
    };
    DetailEvents.LogPort.onEditing = function () {
        $("#content").val(CKEDITOR.instances.content.getData());
    };
    DetailEvents.LogPort.onInserting = function () {
        $("#content").val(CKEDITOR.instances.content.getData());
    };
    DetailEvents.SamplePort.onInserted = function (result) {
        if (result) {
            alert("The sample has been inserted successfully.");
        }
        else {
            alert("The sample has been inserted failed.");
        }
    };
    DetailEvents.SamplePort.onEdited = function () {
        alert("The sample has been edited successfully.");
    };
    DetailEvents.SamplePort.onDeleted = function (key, result) {
        if (!result) {
            alert("Delete failed");
        }
        else {
            $("#samplelistport-collection-" + key).remove();
        }
    };
    DetailEvents.LogPort.onInserted = function (result) {
        if (result) {
            alert("The change log has been inserted successfully.");
        }
        else {
            alert("The change log has been inserted failed.");
        }
    };
    DetailEvents.LogPort.onEdited = function () {
        alert("The change log has been edited successfully.");
    };
    DetailEvents.LogPort.onDeleted = function (key, result) {
        if (!result) {
            alert("Delete failed");
        }
        else {
            $("#loglistport-collection-" + key).remove();
        }
    };
});