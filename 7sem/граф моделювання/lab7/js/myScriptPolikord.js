
window.onload=function(){
	drawC = document.getElementById('bezier');
	drawC2=document.getElementById('bezier2');

	var height = document.body.clientHeight;
	var width = document.body.clientWidth;
	
	drawC.width = width - 30;
	drawC.height = height - 30;
	drawC2.width = width - 30;
	drawC2.height = height - 30;

	c=100;
	cc=100;



	
	if (drawC && drawC.getContext) {
		ctx = drawC.getContext('2d');
		ctx2=drawC2.getContext('2d');

		ctx.fillStyle="#33CC99	"//"#33CC99";
		ctx.lineWidth=1;

		ctx2.fillStyle="#33CC99	"//"#33CC99";
		ctx2.lineWidth=1;
		//=============DRAWING LINES
		//ctx1
		var a=[-0.9,0,-0.2]
		var b=[1,-1,-0.2]
		var c=[150,130,150]
		
		var Ai=[-0.9,0,-0.3];
		var Bi=[1,-1,-0.3];
		var Ci=[500,300,200];
		
		
		
		
		
		//b1===========================
		for(var i=0;i<3;i++){
			
			ctx.beginPath();
			x=5;
			y=(-a[i]*x-c[i])/b[i];
			ctx.moveTo(x,y);

			x=1000;
			y=(-a[i]*x-c[i])/b[i];
			ctx.lineTo(x,y);
			ctx.stroke();

		}
		for(var i=0;i<3;i++){
			ctx2.beginPath();
			x=5;
			y=(-Ai[i]*x-Ci[i])/Bi[i];
			ctx2.moveTo(x,y);

			x=1000;
			y=(-Ai[i]*x-Ci[i])/Bi[i];
			ctx2.lineTo(x,y);
			ctx2.stroke();
		}		


//=============DRAWING LINES END
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
	
	function getPolCoord(x,y){
		Dx=0;
		Dy=0;
		D=0;
		Gx=0;
		Gy=0;
		G=0;
		for(var i=0;i<3;i++){
			for(var j=0;j<3;j++){
				bi=(a[i]*x+b[i]*y+c[i]);
				bj=(a[j]*x+b[j]*y+c[j]);
				
				Dx+=Math.pow(((Ai[i]/bi)-(Ai[j]/bj)),2);

				Dy+=((Ai[i]/bi)-(Ai[j]/bj))*((Bi[i]/bi)-(Bi[j]/bj));
				
				D+=((Ai[i]/bi)-(Ai[j]/bj))*((Ci[i]/bi)-(Ci[j]/bj));


				Gx+=((Ai[i]/bi)-(Ai[j]/bj))*((Bi[i]/bi)-(Bi[j]/bj));

				Gy+=Math.pow(((Bi[i]/bi)-(Bi[j]/bj)),2);
				
				G+=((Bi[i]/bi)-(Bi[j]/bj))*((Ci[i]/bi)-(Ci[j]/bj));
			}
		}

		var koef=Dx/Gx;
		y=(D-G*koef)/(Gy*koef-Dy);
		x=(-G-Gy*y)/Gx;
		//c=c+1;
		//cc=cc+1;
		return [x,y];
	}

	// ctx - rendering context холста, arr - массив точек по которым строим кривую
	// delay - задержка перед отрисовкой следующей точки, pause - пауза перед началом  рисования,
	function drawLines(ctx, arr, delay, pause) {


		if (delay == undefined) {
			delay = 10;
		}
		
		if (pause == undefined) {
			pause = delay;
		}
		var i = 0;
		while (i < arr.length - 1) {
			ctx.beginPath();
			ctx.moveTo(arr[i][0],arr[i][1]);
			ctx.lineTo(arr[i+1][0],arr[i+1][1]);
			ctx.stroke();
			

			var newCoord=getPolCoord(arr[i][0],arr[i][1]);
			ctx2.beginPath();
			ctx2.moveTo(newCoord[0],newCoord[1]);

			newCoord=getPolCoord(arr[i+1][0],arr[i+1][1]);
			ctx2.lineTo(newCoord[0],newCoord[1]);
			ctx2.stroke();
			++i;
		}			
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
	
};