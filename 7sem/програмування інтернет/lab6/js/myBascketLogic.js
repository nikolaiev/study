var dataObj={
    "item1":{
        discount:10,
        price:300,
        title:"Simple host",
        dis_start_from:3,
        max_discount:30,
        external:{
            item1_ssl:{
                price:100,
                title:'SSL'
            },
            item1_space:{
                price:50,
                title:'SPACE'
            }
        }
    },
    "item2":{
        discount:10,
        price:500,
        title:"Profi host",
        dis_start_from:2,
        max_discount:30,
        external:{
            item2_ssl:{
                price:499,
                title:'SSL 1y'
            },
            item2_ssl_longer:{
                price:150,
                title:'SSL 2y'
            }
        }
    },
    "item3":{
        discount:15,
        price:1200,
        title:"Gold host",
        dis_start_from:1,
        max_discount:30,
        external:{
            item3_db:{
                price:600,
                title:'DB'
            },
            item3_promotion:{
                price:2500,
                title:'promotion'
            }
        }
    }
};
//functions
var getById=function(name){return document.getElementById(name);};
var getByClass=function(name){return document.getElementsByClassName(name);};

function Basket(baskID){

    var basketList=getById(baskID);
    var orderList={};//array of ordered elements
    var summ=0;
    var _super=this;
    //functions

    //add element
    this.addElement=(elem)=>{
        /*check if exists*/
       if(elem.extra.length>0){
            var genericType="";
            for(var i in elem.extra){
                genericType+='+ '+dataObj[elem.type].external[/*key is value*/elem.extra[i]].title;
            }
            elem.prevType=elem.type;
            elem.type+=genericType;
            elem.title=genericType;
            console.log(elem)
        }

        if(orderList[elem.type]){
            orderList[elem.type].count+=1;//elem.count;
        }
        else{
            orderList[elem.type]={};
            /*check generic type*/
            orderList[elem.type]=elem//title=dataObj[elem.prevType?elem.prevType:elem.type].title;//elem.count;
            orderList[elem.type].count=1;//elem.count;

        }
        _super.renewList();
        _super.redrawBasket();
    };


    this.renewList=()=>{
        var generalSumm=0;
        var generalAmount=0;
        for(var type in orderList){

            var elem=orderList[type];
            var data=dataObj[elem.prevType?elem.prevType:type];

            //check if title already generated correctly
            if(!elem.title||!elem.title.match(data.title))
                elem.title=elem.prevType?data.title+' '+elem.title:data.title;
            //setting price for simple element
            elem.price=data.price;
            //discount
            var discount=0;
            //counting discount
            if(elem.count >= data.dis_start_from){
                discount=/*elem.count* */data.discount;
                /*if(discount>data.max_discount)
                    discount=data.max_discount;*/
            }

            elem.discount=discount;//in percents
            //prise without external options
            elem.total=(elem.price*(1-elem.discount/100))*elem.count;
            generalSumm+=elem.total;
            generalAmount+=elem.count;

            var external=0;
            if(elem.prevType!=undefined){
                for(var i in elem.extra){
                    for(var j in data.external) {
                        if (j== elem.extra[i]) {
                            external += data.external[j].price;
                            break;
                        }
                    }
                }
            }
            elem.externalPrice=external*elem.count;
            elem.total+=external*elem.count;
        }//end for

        getById('sum').innerHTML=generalSumm;
        getById('totalItemsAmount').innerHTML=generalAmount;
        if(generalSumm==0){
            getById('payButton').classList.add('disabled')
        }
        else{
            getById('payButton').classList.remove('disabled')
        }
    };

    //remove entire element
    this.removeEntireElem=(type)=>{

        delete orderList[type];
        _super.renewList();
        _super.redrawBasket();
    };

    //decrease elem count
    this.decreaseElemCount=(elem)=>{
        if(orderList[elem.type].count==1){
            _super.removeEntireElem(elem.type);
        }
        else{
            orderList[elem.type].count-=1;
            _super.renewList();
            _super.redrawBasket();

        }
    };

    //remove all from basket
    this.clearBasket=()=>{
        orderList={};
        _super.renewList();
        _super.redrawBasket();
    };

    //pay for everything
    this.payForAll=()=>{
        getById('cvvForm').classList.remove('hidden');
    };
    //redrawing basket
    this.redrawBasket=()=>{
        basketList.innerHTML="";
        for(let key in orderList){
            elem=orderList[key];//getting element
            console.log(elem)

            var li=document.createElement('li');
                li.classList.add("list-group");

            li.appendChild(
                ((()=>{var el=document.createElement('div');
                    el.className="view-table";
                    el.appendChild(
                        ((()=>{var el=document.createElement('div');
                            el.className="view-row";
                        //title
                            el.appendChild(
                                ((()=>{var el=document.createElement('div');
                                    el.className='view-name';
                                    el.innerHTML=elem.title;
                                    return el})())
                            );
                            //count
                            el.appendChild(
                                ((()=>{var el=document.createElement('div');
                                    el.className='view-name';
                                    el.innerHTML=elem.count+' item(s)';
                                    return el})())
                            );
                            //price
                            el.appendChild(
                                ((()=>{var el=document.createElement('div');
                                    el.className='view-name';
                                    el.innerHTML=elem.price+'$';
                                    return el})())
                            );
                            //discount
                            el.appendChild(
                                ((()=>{var el=document.createElement('div');
                                    el.className='view-name';
                                    el.innerHTML='-'+elem.discount+'%';
                                    return el})())
                            );
                            //external Price
                            el.appendChild(
                                ((()=>{var el=document.createElement('div');
                                    el.className='view-name';
                                    el.innerHTML='Extra : '+elem.externalPrice+'$';
                                    return el})())
                            );
                            //total price
                            el.appendChild(
                                ((()=>{var el=document.createElement('div');
                                    el.className='view-name';
                                    el.innerHTML='Total: '+elem.total+'$';
                                    return el})())
                            );

                            el.appendChild(
                                ((()=>{var el=document.createElement('div');
                                    el.className='view-name';
                                    el.appendChild(
                                        ((()=>{var el=document.createElement('button');
                                            el.className='btn btn-danger';
                                            el.innerHTML="remove";
                                            el.onclick=(e)=>{
                                                myBasket.removeEntireElem(key);
                                            };
                                            return el})())
                                    );
                                    return el})())
                            );
                            return el})())
                    );
                    return el})())
            );
            //add new li element to basket list
            basketList.appendChild(li);
        }
    };
}