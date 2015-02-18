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
function MakeCategory(obj, selector) {
    if (obj.length > 0)
    {
        for (var i = 0; i < obj.length; i++) {
            $(selector).append('<li><a href="javascript:ShowDocument(' + obj[i].ID + ')">' + obj[i].Title + '</a></li>');
            if (obj[i].Children != null) {
                $(selector).append('<ul id="doc-' + obj[i].ID + '"></ul>');
                MakeCategory(obj[i].Children, "#doc-" + obj[i].ID);
            }
        }
    }
}

function ShowDocument(id)
{
    history.pushState(null, "Documents", "/documents/"+id);
    DetailLocks.DocumentPort = false;
    Detail.DocumentPort = id;
    LoadFromDetailPort("DocumentPort");
    $("#hide").show();
}

function Highlight()
{
    $('.highlight').each(function () {
        var x = $(this).children().children().attr('class');
        $(this).children().children().remove(x);
        x = x.substring(x.indexOf('-') + 1);
        $(this).children().children().addClass(x);
    });
    $('.ckeditor-code').unbind().each(function () {
        var dom = $(this);
        dom.removeClass('ckeditor-code');
        var inner = '<code>' + $(this).html() + '</code>';
        var html = '<div class="highlight"><pre>' + inner + '</pre></div>';
        dom[0].outerHTML = html;
    });
    $('pre code').each(function (i, block) {
        hljs.highlightBlock(block);
    });

    hljs.initHighlightingOnLoad();
}

$(document).ready(function () {
    Highlight();

    if ($("#disqus_thread").length > 0)
    {
        var disqus_shortname = 'yuuko';
        (function () {
            var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
            dsq.src = '//' + disqus_shortname + '.disqus.com/embed.js';
            (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
        })();
    }

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
        Highlight();
        CKEDITOR.replace("summary");
        CKEDITOR.replace("content");
    };
    DetailEvents.LogPort.onLoaded = function () {
        Highlight();
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
        window.location = "/logs";
    };
    DetailEvents.LogPort.onDeleted = function (key, result) {
        if (!result) {
            alert("Delete failed");
        }
        else {
            $("#loglistport-collection-" + key).remove();
        }
    };

    if ($("#doc-root").length > 0)
    {
        $.getJSON("/yuuko/gets/DocumentListPort", null, function (data) {
            MakeCategory(data, $("#doc-root"));
        });
    }

    DetailEvents.DocumentPort.onInserted = function (result) {
        if (result) {
            window.location = "/documents";
        }
        else {
            alert("The sample has been inserted failed.");
        }
    };
    DetailEvents.DocumentPort.onLoaded = function () {
        Highlight();
        CKEDITOR.replace("content");
    };
    DetailEvents.DocumentPort.onEdited = function () {
        window.location = "/documents/"+Detail.DocumentPort;
    };
    DetailEvents.DocumentPort.onDeleted = function (key, result) {
        if (!result) {
            alert("Delete failed");
        }
        else {
            location.reload();
        }
    };
    DetailEvents.DocumentPort.onEditing = function () {
        $("#content").val(CKEDITOR.instances.content.getData());
    };
    DetailEvents.DocumentPort.onInserting = function () {
        $("#content").val(CKEDITOR.instances.content.getData());
    };
});