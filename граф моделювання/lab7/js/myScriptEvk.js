
window.onload=function(){
	drawC = document.getElementById('bezier');
	var height = document.body.clientHeight;
	var width = document.body.clientWidth;
	
	drawC.width = width - 30;
	drawC.height = height - 30;
	
	if (drawC && drawC.getContext) {
		ctx = drawC.getContext('2d');
		ctx.fillStyle="#33CC99	"//"#33CC99";
		ctx.lineWidth=0.1;
		var flow; // Массив координат кривой
		var arr = new Array();
		//top body
		arr[0] = new Array(350, 170);
		arr[1] = new Array(360, 90);
		arr[2] = new Array(500, 110);
		arr[3] = new Array(750, 260);
		arr[4] = new Array(770, 250);		
		flow = getBezierCurve(arr, 0.01);
		drawLines(ctx, flow, 0,0);

		//nose
		arr[0] = new Array(350, 170);
		arr[1] = new Array(340, 192);
		arr[2] = new Array(280, 170);
		arr[3] = new Array(280, 175);
		arr[4] = new Array(350, 200);		
		flow = getBezierCurve(arr, 0.01);
		drawLines(ctx, flow, 0,0);

		//bottom body
		arr[0] = new Array(350, 200);
		arr[1] = new Array(340, 240);
		arr[2] = new Array(500, 210);
		arr[3] = new Array(730, 250);
		arr[4] = new Array(750, 300);		
		flow = getBezierCurve(arr, 0.01);
		drawLines(ctx, flow, 0,0);
		
		//top tail
		arr[0] = new Array(770, 250);
		arr[1] = new Array(810, 250);
		arr[2] = new Array(830, 200);
		arr[3] = new Array(840, 260);
		arr[4] = new Array(770, 270);		
		flow = getBezierCurve(arr, 0.01);
		drawLines(ctx, flow, 0,0);

		//bottom tail
		arr[0] = new Array(770, 270);
		arr[1] = new Array(780, 290);
		arr[2] = new Array(800, 310);
		arr[3] = new Array(790, 370);
		arr[4] = new Array(750, 300	);		
		flow = getBezierCurve(arr, 0.01);
		drawLines(ctx, flow, 0,0);
		
		//bottom paddle 1
		arr[0] = new Array(440, 200);
		arr[1] = new Array(460, 210);
		arr[2] = new Array(490, 330);
		arr[3] = new Array(460, 210);
		arr[4] = new Array(470, 200	);		
		flow = getBezierCurve(arr, 0.01);
		drawLines(ctx, flow, 0,0);
		
		//bottom paddle 2
		// arr[0] = new Array(460, 200);
		// arr[1] = new Array(480, 210);
		// arr[2] = new Array(510, 330);
		// arr[3] = new Array(480, 210);
		// arr[4] = new Array(490, 200	);		
		// flow = getBezierCurve(arr, 0.01);
		// drawLines(ctx, flow, 0,0);
		
		//top paddle 
		arr[0] = new Array(420, 130);
		arr[1] = new Array(460, 110);
		arr[2] = new Array(490, 90);
		arr[3] = new Array(460, 110);
		arr[4] = new Array(470, 130	);		
		flow = getBezierCurve(arr, 0.01);
		drawLines(ctx, flow, 0,0);
		
		//eyes
		var eye_rad=10
		arr[0] = new Array(390, 160);
		arr[1] = new Array(390-eye_rad, 160+eye_rad);
		arr[2] = new Array(390, 160+eye_rad*2);
		arr[3] = new Array(390+eye_rad, 160+eye_rad);
		arr[4] = new Array(390, 160);		
		flow = getBezierCurve(arr, 0.01);
		drawLines(ctx, flow, 0,0);
		
		
	}
	
	//functions
	// i - номер вершины, n - количество вершин, t - положение кривой (от 0 до 1)
	function getBezierBasis(i, n, t) {
		// Факториал
		function f(n) {
			return (n <= 1) ? 1 : n * f(n - 1);
		};
		
		// считаем i-й элемент полинома Берштейна
		return (f(n)/(f(i)*f(n - i)))* Math.pow(t, i)*Math.pow(1 - t, n - i);
	}
	
	// arr - массив опорных точек. Точка - двухэлементный массив, (x = arr[0], y = arr[1])
	// step - шаг при расчете кривой (0 < step < 1), по умолчанию 0.01
	function getBezierCurve(arr, step) {
		if (step == undefined) {
			step = 0.01;
		}
		
		var res = new Array()
		
		for (var t = 0; t < 1 + step; t += step) {
			if (t > 1) {
				t = 1;
			}
			
			var ind = res.length;
			
			res[ind] = new Array(0, 0);
			
			for (var i = 0; i < arr.length; i++) {
				var b = getBezierBasis(i, arr.length - 1, t);
				
				res[ind][0] += arr[i][0] * b;
				res[ind][1] += arr[i][1] * b;
			}
		}
		
		return res;
	}
	
	// ctx - rendering context холста, arr - массив точек по которым строим кривую
	// delay - задержка перед отрисовкой следующей точки, pause - пауза перед началом  рисования,
	function drawLines(ctx, arr, delay, pause) {

		moveX=100;
		moveY=150;

		if (delay == undefined) {
			delay = 10;
		}
		
		if (pause == undefined) {
			pause = delay;
		}
		var i = 0;
		
		function delayDraw() {
			//alert(1)
			if (i >= arr.length - 1) {
				return;				
			}
			ctx.beginPath();
			ctx.moveTo(arr[i][0],arr[i][1]);
			ctx.lineTo(arr[i+1][0],arr[i+1][1]);
			ctx.stroke();

			//evklid
			ctx.beginPath();
			ctx.moveTo(arr[i][0]+moveX,arr[i][1]+moveY);
			ctx.lineTo(arr[i+1][0]+moveX,arr[i+1][1]+moveY);
			ctx.stroke();
		
			++i;
			delayDraw();
			//setTimeout(delayDraw, delay);
		}
		delayDraw();
		//setTimeout(delayDraw, pause);
	}

	

};