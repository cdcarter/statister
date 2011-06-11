function(head, req) { 
	var mustache = require("vendor/couchapp/lib/mustache")
	var row;
	var team = "";
	start({ "headers": { "Content-Type": "plain/text" } }); 
	send('"')
	
	while(row = getRow()) {
		//row.key = [gameID,teamname] 
		//row.value = playername 
		if (row.key[1] != team) { 
			team = row.key[1] 
			send('<h2 class=team data-round='+row.key[2]+'>'+row.key[1]+'</h2>') 
		}

		var template = "<input type=radio name=player data-name={{name}} data-team={{team}} value={{name}}>{{name}}</input><br>"
		var data = {name: row.value, team: team}
 		send(mustache.to_html(template,data));
	}
	send('"')
}
