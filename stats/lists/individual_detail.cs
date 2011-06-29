(head,req)->
  mustache = require("vendor/couchapp/lib/mustache")
  view = req.path[req.path.length-1]
  
  start { "headers": {"Content-Type": "text/html"}}
  
  player = []
  
  switch view
    when "individual"
      while row = getRow()
        split = row.key.splice(1,2)
        if player[0] != split[0] && player[1] != split[1]
          player = split
          log(player)
          send("<h2><a id=#{row.id}>#{player[1]}</a>, #{player[0]}</h2>")