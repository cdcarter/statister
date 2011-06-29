(head,req) ->
  mustache = require("vendor/couchapp/lib/mustache")
  round = 0
  view = req.path[req.path.length-1]
  bracket = ''
	
  start { "headers": {"Content-Type": "text/html"}}

  while row = getRow()
    if row.key[0] != round
      round = row.key[0] 
      send("<h1>#{round}</h1>")
			
    if (row.key[1] != bracket)
      bracket = row.key[1] 
      send("<h2>#{bracket}</h2>")
		
		# row.key = [round,bracket,room]
		# row.value = [teamA,teamB]
		
    doc = {"id":row.id,"round":row.key[0],"bracket":row.key[1],"room":row.key[2],"teamA":row.value[0],"teamB":row.value[1]}
    send mustache.to_html(this.templates.gamerow,doc)
  
