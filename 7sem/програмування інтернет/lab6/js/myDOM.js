//global data
var myBasket=new Basket('baskList');
var itemsIds=["item1","item2","item3"];//ids of elements to buy

//elements
var basketList=document.getElementById('baskId');
var baskAction=document.getElementById('baskAct');//button Show basket

//functions
var getById=function(name){return document.getElementById(name);};
var getByClass=function(name){return document.getElementsByClassName(name);};


baskAction.onclick=function () {
    var value=getById('baskActText').innerHTML;

    getById('baskActText').innerHTML=value=="Show"?"Hide":"Show";

    var basket=getByClass('basket')[0];

    if(basket.classList.contains("hidden")){
        basket.classList.remove("hidden");
    }
    else {
        basket.classList.add("hidden");
    }
};


//обработка чекбоксов при нажатии кнопок "купить"
itemsIds.forEach((elem,index)=>{
    getById(elem).onclick=(e)=>{

        var data=dataObj[elem];
        var extra=[];
        for( var chBoxId in data.external){
            if(getById(chBoxId).checked)
                extra.push(chBoxId);
        }
        myBasket.addElement({type:elem,extra:extra});
    }
});

//очистить всю корзину
getById('clearBaskButt').onclick=()=>{
    myBasket.clearBasket();
};

//======ФОРМА ОПЛАТЫ
//оплатить 
getById('payButton').onclick=()=>{
  myBasket.payForAll();
};

//отменить оплату
getById('cancelButton').onclick=()=>{
    getById('cvvForm').classList.add('hidden');
};

//поля ввода в форме оплаты
/*атрибут pattern не работает в инпут 
пришлось писать его обработку самому*/
//неправильно работает, если вставлять из буффера длинную строку
var inputs=document.getElementsByTagName('input')

for(var input in inputs){
    let elem=inputs[input];
    if(elem.type=='text'
        && elem.getAttribute("pattern")){
        elem.onkeyup=(e)=>{
        	//массив подстрок(должна быть только 1)        	
            let sustr_arr=elem.value.match(/*атрибут паттерн*/elem.getAttribute("pattern"))
            if(sustr_arr==null){
               	elem.value=elem.value.substring(0, elem.value.length - 1);
            }

        }
    }

}

