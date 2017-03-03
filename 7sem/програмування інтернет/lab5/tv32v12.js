	document.addEventListener('DOMContentLoaded', m);

	function m() {

		let arr  = ["Lection 1","Lection 1","Lection 1","Lection 1","Lection 1","Lection 1","Lection 1","Lection 1","Lection 1",],
		linksArray = document.querySelectorAll('a'),
		modalWindow,
		oldTitleText,
		linkContext;
	
		document.getElementById("links-section").addEventListener('click', linkHandler);

		function linkHandler(event) {

			function workWithModalWindow(link) {
				linkContext = link;
				var lectionIndex = undefined;

				Array.prototype.forEach.call(linksArray, function(item, index){
					if(item == link) {
						lectionIndex = index;
					}
				});

				modalWindow =  window.open("about:blank", link.text, "width=500,height=500");
				modalWindow.document.write(arr[lectionIndex]);
				oldTitleText = link.text;
				link.text = "openned";
			}

			if(event.target.localName == "a") {
				event.preventDefault();

				if(!linkContext) {
					workWithModalWindow(event.target);
				} else {
					linkContext.text = oldTitleText;
					modalWindow.close();
					if(event.target !=linkContext) {
						workWithModalWindow(event.target);
					} else {
						linkContext = null;
					}
					
					return;
				}
			}
	}
	}



/* Marquee */

var marqueeInterval;

var marqueeSubmit = document.getElementById("marquee-submit");
marqueeSubmit.onclick = function () {
    var marqueeText = document.getElementById("marquee-text").value;
    var element = document.getElementById("marquee-element");
    element.innerHTML = marqueeText;

    if (marqueeInterval) {
        clearInterval(marqueeInterval);
        element.style.left = 0;
    }

    var marqueeFunction = function () {
        var windowWidth = window.innerWidth;
        var left = parseInt(element.style.left) ? parseInt(element.style.left) : 0;
        if (left > windowWidth) {
            element.style.left = 0;
        } else {
            left += 3;
            element.style.left = left + "px";
        }
    };

    marqueeInterval = setInterval(marqueeFunction, 50);
};

/* GET */

var button = document.getElementById("get-parameters-button");

button.onclick = function () {

    function findGetParameters() {
        var result = {};
        location.search
            .substr(1)
            .split("&")
            .forEach(function (item) {
                var parameterNameAndValue = item.split("=");
                if (parameterNameAndValue.length === 1) {
                    parameterNameAndValue.push("");
                }
                result[parameterNameAndValue[0]] = parameterNameAndValue[1];
            });
        return result;
    }

    document.getElementById("element-to-write-get-params").innerHTML = JSON.stringify(findGetParameters());

};