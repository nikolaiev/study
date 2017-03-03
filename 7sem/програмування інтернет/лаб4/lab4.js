function Machine(){
	this.name="Machine Name";
	this.brand="Machine Brand";
	this.onStatus=false;//private var
}

Machine.prototype.onButton=function(){
	this.onStatus=!this.onStatus;
}

//creating new object with private functions and fields!
var CoffeeMachine=(function (){
	//используем замыкания для создания приватных свойств

	var WATER_HEAT_CAPACITY=4200;//приватная переменная
	var waterAmountPrivate=0;//приватная переменная

	
	//constructor
	function CoffeeMachine(power,water/*private var*/){	
		this.power=power;
		waterAmountPrivate=water;
	}

	CoffeeMachine.prototype=new Machine();//not Object create --IE 8
	/*
	function inherit(proto) {
	  function F() {}
	  F.prototype = proto;
	  var object = new F;
	  return object;
	}*/

	//extending
	CoffeeMachine.prototype.onButton=function(){
		//super function
		Machine.prototype.onButton.call(this);
		//extending
		console.log(this.name+ " is "+(this.onStatus?"off":"on")+" now" );
	}

	//some kind of setter / getter
	CoffeeMachine.prototype.waterAmount=function(val){
		if(val){
			if(val>0&& val<=WATER_HEAT_CAPACITY)
				waterAmountPrivate=val;
			else if(val<=0)
				waterAmountPrivate=0;
			else
				waterAmountPrivate=WATER_HEAT_CAPACITY;
		}

		else{
			return waterAmountPrivate;
		}
	}

	//adding water method
	CoffeeMachine.prototype.addWater=function(/*количество воды для добавления*/watAmount){
		console.log('addWater function')
		if(watAmount>0)
			this.waterAmountPrivate+=watAmount;
	}


	//pretty time show function
	CoffeeMachine.prototype.getExactTime=function(){
		var exactTime=getBoilTime(this);//min
		console.log('time is '+exactTime+' min');
		
		var hours =Math.floor(exactTime/60);
		var minutes = Math.floor(exactTime%60);

		var seconds = Math.round(exactTime%1*60	);

		//var _=[1];//час[] // минутА //секундА
		var _a=[2,3,4];//час[а] // минутЫ секундЫ
		var _aa=[0,5,6,7,8,9,10,11,12,13,14];// часОВ //минут_ // секунд_
		console.log(hours%10)

		//pretty string
		var resStr=

				hours
				+
				' '
				+ (_aa.indexOf(hours%100)!=-1 ||_aa.indexOf(hours%10)!=-1 
						?
							'часов'
						:
							(_a.indexOf(hours%10)!=-1
								?
									'часа'
								:
									'час'))
				+
				' '
				+
				minutes
				+
				' '
				+ (_aa.indexOf(minutes%100)!=-1 ||_aa.indexOf(minutes%10)!=-1 
						?
							'минут'
						:
							(_a.indexOf(minutes%10)!=-1
								?
									'минуты'
								:
									'минута'))
				+

				' '
				+
				seconds
				+
				' '
				+ (_aa.indexOf(seconds%100)!=-1 ||_aa.indexOf(seconds%10)!=-1 
						?
							'секунд'
						:
							(_a.indexOf(seconds%10)!=-1
								?
									'секунды'
								:
									'секунда'));

		return resStr;
	}

	//run method
	CoffeeMachine.prototype.run=function(){
			setTimeout(onReady,getBoilTime(this))
		}

	/*private methods*/
	function getBoilTime(self){
		return self.waterAmount()*WATER_HEAT_CAPACITY*80/self.power;//min;
	}

	function onReady(){
		console.log('Coffee is done!');
	}

	return CoffeeMachine;

}());


var myCoffeMachine = new CoffeeMachine(10000,500);



console.log(myCoffeMachine)
console.log(myCoffeMachine.waterAmount())

myCoffeMachine.onButton();

console.log(myCoffeMachine.name)
console.log(myCoffeMachine.brand)
console.log(myCoffeMachine.onStatus)

myCoffeMachine.waterAmount(512)

console.log(myCoffeMachine.waterAmount())


myCoffeMachine.run();
console.log(myCoffeMachine.getExactTime());


