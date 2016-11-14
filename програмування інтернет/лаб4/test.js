function Machine(){
	this.name="Machine Name";
	this.brand="Machine Brand";
	this.onStatus=false;//private var
}

Machine.prototype.onButton=function(){
	this.onStatus=!this.onStatus;
}

function CoffeeMachine(power/*private var*/){	

	//console.log(this.__proto__)
	var WATER_HEAT_CAPACITY=4200;//приватная переменная
	var waterAmountPr=0;//приватная переменная
	//this.power=power;

	var self=this;

	Object.defineProperties(this,
	{
	    "waterAmount": { 
	    	set: function (x/*litre*/) {
	    		if(x>WATER_HEAT_CAPACITY)
	    			wa=WATER_HEAT_CAPACITY;
	    		else if(x<0)
	    			wa=0;
	    		else
	    		 	wa=x; 
	    	},
	    	get: function () {return wa; }}
	});

	this.addWater=function(/*количество воды для добавления*/watAmount){
		console.log('addWater function')
		if(watAmount>0)
			this.waterAmount+=watAmount;		
		//else
			//throw new Error('Invalid argument');
	}
	
	this.run=function(){
		setTimeout(onReady,getBoilTime())
	}

	this.getExactTime=function(){
		var exactTime=getBoilTime();//min
		
		var hours =Math.floor(exactTime/60);
		var minutes = Math.floor(exactTime%60);
		var seconds = Math.round(exactTime%1*0.6);

		//TODO
		console.log('YOU SHOULD CREATE PRETTY OUTPUT STRING!')
		console.log(hours)
		console.log(minutes)
		console.log(seconds)
		return exactTime;
	}


	/*private methods*/

	function getBoilTime(){
		return self.waterAmount*WATER_HEAT_CAPACITY*80/power;//min;
	}

	function onReady(){
		console.log('Coffee is done!');
	}

}

CoffeeMachine.prototype=Object.create(Machine);



var myCoffeMachine =new CoffeeMachine(100000);

console.log(myCoffeMachine.name)
console.log(myCoffeMachine.brand)




