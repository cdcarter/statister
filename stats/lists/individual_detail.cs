(head,req)->
  mustache = require("vendor/couchapp/lib/mustache")
  view = req.path[req.path.length-1]
  
  start { "headers": {"Content-Type": "text/html"}}
  
  player = []
  acc = {pts: 0, tuh:0, tens:0, negs:0,gp:0}
  
  template = "<tr><td>{{#acc}}<b>{{/acc}}{{opponent}}{{#acc}}</b>{{/acc}}</td><td>{{gp}}</td><td>{{tuh}}</td><td>{{tens}}</td>
              <td>{{negs}}</td><td>{{ppth}}</td><td>{{pts}}</td><td>{{ppg}}</td></tr>"
  
  switch view
    when "individual"
      while row = getRow()
        split = row.key.splice(1,2)
        if player[0] != split[0] || player[1] != split[1]
          
          unless player.length == 0
            acc.opponent = "Total"
            acc.ppth = acc.pts / acc.tuh
            acc.ppg = acc.pts / acc.gp
            acc.acc = true
            send(mustache.to_html template,acc)
            acc = {pts: 0, tuh:0, tens:0, negs:0,gp:0}
            send("</table>")
          
          player = split
          
          send("<h2><a id=#{row.id}>#{player[1]}</a>, #{player[0]}</h2>")
          send("<table><tr><th>Opponent</th><th>GP</th><th>TUH</th><th>10</th><th>-5</th><th>PPTH</th><th>Pts</th>")
        
        row.value.gp = row.value.tuh / 20
        send(mustache.to_html template,row.value)
        acc.pts += row.value.pts
        acc.tuh += row.value.tuh
        acc.tens += row.value.tens
        acc.negs += row.value.negs
        acc.gp += row.value.gp
        
  return ""
        