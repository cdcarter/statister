(head,req)->
  mustache = require("vendor/couchapp/lib/mustache")
  view = req.path[req.path.length-1]
  
  start { "headers": {"Content-Type": "text/html"}}
  
  player = []
  
  template = "<tr><td>{{opponent}}</td><td>{{tuh}}</td><td>{{tens}}</td><td>{{negs}}</td><td>{{ppth}}</td><td>{{pts}}</td></tr>"
  
  switch view
    when "individual"
      while row = getRow()
        split = row.key.splice(1,2)
        if player[0] != split[0] || player[1] != split[1]
          player = split
          send("</table>") unless player == []
          send("<h2><a id=#{row.id}>#{player[1]}</a>, #{player[0]}</h2>")
          send("<table><tr><th>Opponent</th><th>TUH</th><th>10</th><th>-5</th><th>PPTH</th><th>Pts</th>")
        
        send(mustache.to_html template,row.value)
        
        