function getPi(method){
	var currentPi;
	//код
	
	if (method==1){
		var _method1 = function(){
			return "ряд (4-я формула)"
		};
		_method1.compute = function(){
			currentPi = 0
			var work = true; 
			for(var k=0;k<100000;k++)
			{
				currentPi += (Math.pow(-1, k))/(Math.pow(3, k)*(2*k+1));
				//console.log(currentPi+' '+step)
			}
			currentPi*=2*Math.pow(3,1/2)
			return (currentPi)
			//Math.pow(4, 3);
		}
		_method1.clear = function(){
			currentPi=0;
			return currentPi;
		}
		return _method1;
	}
	if (method==2){
		var _method2 = function(){
			return "метод Монте-Карло"
		};
		_method2.compute = function(){
			var pointsIn = 0;
			var points = 10000000
			for (var i = 0; i < points; i++) {
				x = Math.random();
				y = Math.random();
				dist = Math.pow(x ,2) + Math.pow(y ,2) ;
				dist = Math.sqrt(dist);
				if (dist <= 1) {
					pointsIn++;
				}
			}
			return 4*pointsIn/points;
		}
		_method2.clear = function(){
			currentPi=0;
			return currentPi;
		}
		return _method2;
	}
	if (method==3){
		var _method3 = function(){
			return "произведения (7-я формула)"
		};
		
		_method3.compute = function(){
			currentPi = 1;
			var work = true; 
			for(var k=1;k<1000;k++)
			{
				currentPi *= (Math.pow(k,2)+k)/(Math.pow(k,2)+k+1/4);				
			}
			currentPi*=4;
			return (currentPi);
			//Math.pow(4, 3);
		}
		_method3.clear = function(){
			currentPi=0;
			return currentPi;
		}
		return _method3;
	}
	return 'method undefined'
}

method1 = getPi(1);
method2 = getPi(2);
method3 = getPI(3);

print(method1());
print(method2());
print(method3());

print(method1.compute());
print(method2.compute());
print(method3.compute());