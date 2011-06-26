function(head, req) {
	var mustache = require("vendor/couchapp/lib/mustache")
	var row;
	var round = 0;
	var bracket = '';
	
  start({
    "headers": {
      "Content-Type": "text/html"
     }
  });
  while(row = getRow()) {
		if (row.key[0] != round) { 
			round = row.key[0] 
			send('<h1>'+round+'</h1>')
		}
		if (row.key[1] != bracket) { 
			bracket = row.key[1] 
			send('<h2>'+bracket+'</h2>')
		}
		// row.key = [round,bracket,room]
		// row.value = [teamA,teamB]
		var doc = {"id":row.id,"round":row.key[0],"bracket":row.key[1],"room":row.key[2],"teamA":row.value[0],"teamB":row.value[1]}
    send(mustache.to_html(this.templates.gamerow,doc));
  }
}