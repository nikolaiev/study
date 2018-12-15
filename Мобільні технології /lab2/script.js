var plot = document.getElementById('plot');
mouseY = 0;
mouseStop = false;
		var svgPlot = document.getElementById('svgPlot');
		var svgPlot1 = document.getElementById('svgPlot1');
		var editorPlot = document.getElementById('editorPlot');
		var editorMap = document.getElementById('editorMap');
		function flowsRender() {
			var str = "";
			for (var i = 0; i < flows.length; i++) {
				var x = flows[i].x;
				var y = flows[i].y;
				var vx = flows[i].vx;
				var vy = flows[i].vy;
				// var dx = x - (vx + x);
				// var dy = y - (vy + y);
				// var k = dx/dy;
				// var dist = Math.sqrt(dx*dx + dy*dy);
				str += `<path d="M${x} ${y} L${vx+x} ${vy+y}" fill='none' stroke='red' stroke-width='1'  marker-start="url(#MarkerCircle)" marker-end="url(#arrow1)"  />`;
			}
			// plot.setAttribute('d', str);
			// svgPlot.innerHTML += str;
			flowsText = str;
			// svgPlotText = svgPlot.innerHTML;
		}
		var flowsText = "";
		flowsRender();
		var svgPlotText = svgPlot.innerHTML;
		var editorPlotText = editorPlot.innerHTML;
		var oil = [];
		var oilDen = .1;
		var oilRad1 = 50;
		var oilRad2 = 50;
		var oilCenterX = 700;
		var oilCenterY = 200;
		var running = false;

		var vh = 0.1;
		var oilPercentage = 10;

		oilDistribution();
svgPlot.addEventListener('mousemove', e  => {
	if(!mouseStop)
	mouseY = e.clientY
})
svgPlot.addEventListener('click', e  => {
	mouseStop = !mouseStop
	alertify.set('notifier','position', 'top-left');
	alertify.warning('Line ' + (mouseStop ? 'stop' : 'move'));
})
		function oilDistribution() {
			var textElements = "";
			for(var i = 0; i < oilRad2; i+=oilDen*3) {
				for(var j = 0; j < oilRad1; j+=oilDen*3) {
					if(j < oilRad1/2) {
						if (((i - oilRad2/2) - Math.sqrt(j) < 0) && ((i - oilRad2/2) + Math.sqrt(j) > 0)) {
							var x = oilCenterX+(j-oilRad1/2)*(1/oilDen);
							var y = oilCenterY-(i-oilRad2/2)*(1/oilDen);
							textElements +=
							`<circle cx="${x}" cy="${y}" r="5" stroke="black"
							stroke-width=".5" fill="purple" />`;
							oil.push({x:x,y:y,h:0})
						}
					} else {
						if (((i - oilRad2/2) - Math.sqrt(-j + oilRad1) < 0) && ((i - oilRad2/2) + Math.sqrt(-j + oilRad1) > 0)) {
							var x = oilCenterX+(j-oilRad1/2)*(1/oilDen);
							var y = oilCenterY-(i-oilRad2/2)*(1/oilDen);
							textElements +=
							`<circle cx="${x}" cy="${y}" r="5" stroke="black"
							stroke-width=".5" fill="purple" />`;
							oil.push({x:x,y:y,h:0})
						}
					}
				}
			}
			svgPlot.innerHTML = svgPlotText + textElements;
		}

		function oilRender() {
			var textElements = "";
			for(var i = 0; i < oil.length; i++) {
				var x = oil[i].x;
				var y = oil[i].y;
				var vx = oil[i].vx;
				var vy = oil[i].vy;

				textElements +=
				`<circle cx="${x}" cy="${y}" r="5" stroke="black"
				stroke-width=".4" fill="purple" />`;
				// `<path d="M${x} ${y} L${vx+x} ${vy+y}" fill='none' stroke='black' stroke-width='1'  marker-end="url(#arrow2)"/>`;
				// oil.push({x:x,y:y,h:0});
			}
			const mouseLine = drawLine(mouseY);
			const oilToDepth = addFlowInLine(mouseY)
			svgPlot.innerHTML = svgPlotText + textElements + flowsText + mouseLine + oilToDepth + vertLine();
		}



		function drawLine(y) {
			return `<line x1="0" y1="${y}" x2="950" y2="${y}" style="stroke:rgb(255,0,0);stroke-width:2" />
			<line x1="0" y1="${y-10}" x2="950" y2="${y-10}" style="stroke:rgb(255,165,0);stroke-width:2" />
			<line x1="0" y1="${y+10}" x2="950" y2="${y+10}" style="stroke:rgb(255,165,0);stroke-width:2" />`
		}	

		function vertLine() {
			return '<line x1="950" y1="0" x2="950" y2="900" style="stroke:rgb(0,0,0);stroke-width:2" />'
		}

		function addFlowInLine(y) {
			oilToDepth='';
			oil.forEach(o => {
				if(o.y <= y+10 && o.y >= y-10)
				{
					const height = o.h*10+10 < 570 ? o.h*10 +10  : 570
					oilToDepth += `<circle cx="${950+o.x/950*900}" cy="${height}" r="5" stroke="black"
				stroke-width=".5" fill="purple" />`
				}
			})
return oilToDepth

		}


		function moveOil(elem) {
			var minimum = [flows[0],flows[1],flows[2]];
			// for(k = 0; k < 3; k++)
			var dist0,dist1,dist2;
			for (var i = 0; i < flows.length; i++) {
				flows[i].id = i + "";
				var dx = elem.x - flows[i].x;
				var dy = elem.y - flows[i].y;
				var dist = Math.sqrt(dx*dx+dy*dy);
				var dx0 = elem.x - minimum[0].x;
				var dy0 = elem.y - minimum[0].y;
				dist0 = Math.sqrt(dx0*dx0+dy0*dy0);
				var dx1 = elem.x - minimum[1].x;
				var dy1 = elem.y - minimum[1].y;
				dist1 = Math.sqrt(dx1*dx1+dy1*dy1);
				var dx2 = elem.x - minimum[2].x;
				var dy2 = elem.y - minimum[2].y;
				dist2 = Math.sqrt(dx2*dx2+dy2*dy2);
				if(dist0 > dist && minimum[0].id !== minimum[1].id && minimum[0].id !== minimum[2].id) {
					// var b = minimum[0];
					// minimum[1] = b;
					minimum[0].x = flows[i].x;
					minimum[0].y = flows[i].y;
					minimum[0].vx = flows[i].vx;
					minimum[0].vy = flows[i].vy;
					minimum[0].id = flows[i].id;
				}
				if(dist1 > dist && minimum[1].id !== minimum[0].id && minimum[1].id !== minimum[2].id) {
					// var b = minimum[1];
					// minimum[2] = b;
					minimum[1].x = flows[i].x;
					minimum[1].y = flows[i].y;
					minimum[1].vx = flows[i].vx;
					minimum[1].vy = flows[i].vy;
					minimum[1].id = flows[i].id;
				}
				if(dist2 > dist && minimum[2].id !== minimum[0].id && minimum[2].id !== minimum[1].id) {
					minimum[2].x = flows[i].x;
					minimum[2].y = flows[i].y;
					minimum[2].vx = flows[i].vx;
					minimum[2].vy = flows[i].vy;
					minimum[2].id = flows[i].id;
				}
			}
			// console.log(minimum[0],minimum[1],minimum[2]);
			var sdist = Math.sqrt(dist0*dist0+dist1*dist1+dist2*dist2);
			var vx = (dist0/sdist)*minimum[0].vx + (dist1/sdist)*minimum[1].vx + (dist2/sdist)*minimum[2].vx;
			var vy = (dist0/sdist)*minimum[0].vy + (dist1/sdist)*minimum[1].vy + (dist2/sdist)*minimum[2].vy;
			// var z = averVec(minimum[0],averVec(minimum[1],minimum[2]));
			var q = {x:elem.x,y:elem.y,vx:vx,vy:vy};
			// q.vx = minimum[0].vx;
			// q.vy = minimum[0].vy;
			// q.x = elem.x;
			// q.y = elem.y;
			return q;
		}

		function averVec(v1, v2) {
			var v3 = {vx:0, vy:0,x:0,y:0};
			v3.vx = (v1.vx+v2.vx)/2;
			v3.vy = (v1.vy+v2.vy)/2;
			return v3;
		}

		var timer;
		var showSection = false;

		function prevStep() {
			if(running) {
				clearInterval(timer);
				running = false;
				// document.getElementById('stopButton').innerHTML = "<h1>Toggle section</h1>";
			// } else {
			// 	// show section
			// 	showSection = !showSection;
			// 	renderSection();
			}
		}

		function toggleSection() {
			showSection = !showSection;
			renderSection();
		}

		function renderSection() {
			if(showSection) {
				svgPlot.style.display = 'none';
				svgPlot1.style.display = 'block';
				var textElements = "";
				for(var i = 0; i < oil.length; i++) {
					var x = oil[i].x;
					var h = oil[i].h;
					// var vx = oil[i].vx;
					// var vy = oil[i].vy;
					// console.log(x);
					textElements +=
					`<circle cx="${i/oil.length*1000}" cy="${h}" r="5" stroke="black"
					stroke-width=".5" fill="purple" />`;
					// `<path d="M${x} ${y} L${vx+x} ${vy+y}" fill='none' stroke='black' stroke-width='1'  marker-end="url(#arrow2)"/>`;
					// oil.push({x:x,y:y,h:0});
				}
				svgPlot1.innerHTML = textElements;
			} else {
				svgPlot.style.display = 'block';
				svgPlot1.style.display = 'none';
			}
		}

		function nextStep() {
			var delta = 10;
			running = true;
			document.getElementById('stopButton').innerHTML = "<span>Stop</span>";
			timer = setInterval(function() {
				var dt = .1;
				counter = 0;
				for (var i = 0; i < oil.length; i++) {
					var q = moveOil(oil[i]);
					oil[i].vx = q.vx;
					oil[i].vy = q.vy;
					if(oil[i].vx*dt + oil[i].x >= 0 && oil[i].vx*dt + oil[i].x <= 950)
						oil[i].x = oil[i].vx*dt + oil[i].x;
					if(oil[i].vy*dt + oil[i].y >= 0 && oil[i].vy*dt + oil[i].y <= 900)
						oil[i].y = oil[i].vy*dt + oil[i].y;
					if(counter > 100) {
						oil[i].h += Math.sqrt(oil[i].vx*oil[i].vx+oil[i].vy*oil[i].vy)*dt*vh;
						counter = 100-counter;
					}
					counter += oilPercentage;
					// console.log('new x:',oil[i].x);
				}
				renderSection();
				oilRender();
				// console.log('render');
				// 
			}, delta);
		}

		function timerStep(dt) {
			for (var i = 0; i < oil.length; i++) {
				var q = moveOil(oil[i]);
				oil[i].vx = q.vx;
				oil[i].vy = q.vy;
				oil[i].x = oil[i].vx*dt + oil[i].x;
				oil[i].y = oil[i].vy*dt + oil[i].y;
				// console.log('new x:',oil[i].x);
			}
			oilRender();
		}

		function download() {
			var element = document.createElement('a');
			var text = {oil:oil, flows:flows};
			text = JSON.stringify(text);
			element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(text));
			element.setAttribute('download', 'map.txt');

			element.style.display = 'none';
			document.body.appendChild(element);

			element.click();

			document.body.removeChild(element);
		}

		function switchTab(name) {
			var menu = document.getElementById('menu');
			var editor = document.getElementById('editor');
			var map = document.getElementById('map');
			switch (name) {
				case 'menu':
					menu.style.display = "flex";
					editor.style.display = "none";
					map.style.display = "none";
				break;
				case 'editor':
					menu.style.display = "none";
					editor.style.display = "flex";
					map.style.display = "none";
					renderEditor();
					// console.log(getWidth());
				break;
				case 'map':
					menu.style.display = "none";
					editor.style.display = "none";
					map.style.display = "flex";
					oilRender();
					flowsRender();
				break;
			}
		}

		var placing = false;
		var placeType = 'none';

		function placeArrow() {
			placeType = 'arrow';
		}

		function placeOil() {
			placeType = 'oil';
			placing = false;
		}

		function placeCancel() {
			oil = [];
			flows = [];
			flowsRender();
			renderEditor();
		}

		function getWidth() {
			return Math.max(
				document.body.scrollWidth,
				document.documentElement.scrollWidth,
				document.body.offsetWidth,
				document.documentElement.offsetWidth,
				document.documentElement.clientWidth
			);
		}

		function getHeight() {
			return Math.max(
				document.body.scrollHeight,
				document.documentElement.scrollHeight,
				document.body.offsetHeight,
				document.documentElement.offsetHeight,
				document.documentElement.clientHeight
			);
		}

		function place(el) {
			// console.log(e);
			var editorPlot = document.getElementById('editorPlot');
			var rect = editorPlot.getBoundingClientRect();
			// var x = (el.clientX / getWidth()) * 800;
			// var y = ((el.clientY - rect.top) / getHeight()) * 600;
			var x = el.clientX;
			var y = el.clientY - rect.top;
			if(placeType === 'arrow') {
				if(placing) {
					flows[flows.length-1].vx = x - flows[flows.length-1].x;
					flows[flows.length-1].vy = y - flows[flows.length-1].y;
					placing = false;
					renderEditor();
				} else {
					flows.push({x:x,y:y})
					placing = true;
				}
			} else if (placeType === 'oil') {
				oil.push({x:x,y:y,h:0})
				renderEditor();
				console.log('render editor');
			}
			// console.log(el);
			// console.log(getHeight(), getWidth());
		}

		function renderEditor() {
			var textElements = "";
			for(var i = 0; i < oil.length; i++) {
				var x = oil[i].x;
				var y = oil[i].y;
				// console.log(x);
				textElements +=
				`<circle cx="${x}" cy="${y}" r="5" stroke="black"
				stroke-width=".5" fill="purple" />`;
				// oil.push({x:x,y:y,h:0});
			}
			for (var i = 0; i < flows.length; i++) {
				var x = flows[i].x;
				var y = flows[i].y;
				var vx = flows[i].vx;
				var vy = flows[i].vy;
				textElements += `<path d="M${x} ${y} L${vx+x} ${vy+y}" fill='none' stroke='red' stroke-width='1'  marker-start="url(#MarkerCircle)" marker-end="url(#arrow)";
				 />`;
			}
			editorPlot.innerHTML = editorPlotText + textElements + vertLine() 	;
		}

	var reader; //GLOBAL File Reader object for demo purpose only

    /**
     * Check for the various File API support.
     */
    function checkFileAPI() {
        if (window.File && window.FileReader && window.FileList && window.Blob) {
            reader = new FileReader();
            return true;
        } else {
            alert('The File APIs are not fully supported by your browser. Fallback required.');
            return false;
        }
    }

    /**
     * read text input
     */
    function readText(filePath) {
        var output = ""; //placeholder for text output
        if(filePath.files && filePath.files[0]) {
            reader.onload = function (e) {
                output = e.target.result;
                displayContents(output);
            };//end onload()
            reader.readAsText(filePath.files[0]);
        }//end if html5 filelist support
        else if(ActiveXObject && filePath) { //fallback to IE 6-8 support via ActiveX
            try {
                reader = new ActiveXObject("Scripting.FileSystemObject");
                var file = reader.OpenTextFile(filePath, 1); //ActiveX File Object
                output = file.ReadAll(); //text contents of file
                file.Close(); //close file "input stream"
                displayContents(output);
            } catch (e) {
                if (e.number == -2146827859) {
                    alert('Unable to access local files due to browser security settings. ' +
                     'To overcome this, go to Tools->Internet Options->Security->Custom Level. ' +
                     'Find the setting for "Initialize and script ActiveX controls not marked as safe" and change it to "Enable" or "Prompt"');
                }
            }
        }
        else { //this is where you could fallback to Java Applet, Flash or similar
            return false;
        }
        return true;
    }

    /**
     * display content using a basic HTML replacement
     */
    function displayContents(txt) {
        // var el = document.getElementById('main');
        // el.innerHTML = txt; //display output in DOM
		// console.log(txt);
		var inputData = JSON.parse(txt);
		flows = [];
		oil = [];
		flowsText = "";
		oil = inputData.oil;
		flows = inputData.flows;
		flowsRender();
		oilRender();
    }

		switchTab('map');
