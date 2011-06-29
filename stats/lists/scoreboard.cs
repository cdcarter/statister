(head,req)->
  mustache = require("vendor/couchapp/lib/mustache")
  round = 0
  view = req.path[req.path.length-1]
  
  start { "headers": {"Content-Type": "text/html"}}
  
  template= "<h2>{{teamA}} {{teamAscore}}, {{teamB}} {{teamBscore}}</h2>
  {{teamA}}: {{#teamAstats}} {{name}} {{tens}} {{negs}} {{tuh}} {{/teamAstats}}<br>
  {{teamB}}: {{#teamBstats}} {{name}} {{tens}} {{negs}} {{tuh}} {{/teamBstats}}<br>
  Bonuses: {{teamA}} {{teamAbhrd}} {{teamAbpts}} {{teamAppb}}, {{teamB}} {{teamBbhrd}} {{teamBbpts}} {{teamBppb}}
  "
  
  switch view
    when "by_round"
      while row = getRow()
        if row.doc["round"] != round
          round = row.doc["round"]
          send("<h1>#{round}</h1>")
        
        row.doc.teamAppb = (row.doc.teamAbpts / row.doc.teamAbhrd).toFixed 2
        row.doc.teamBppb = (row.doc.teamBbpts / row.doc.teamBbhrd).toFixed 2
        
        
        send(mustache.to_html template, row.doc)