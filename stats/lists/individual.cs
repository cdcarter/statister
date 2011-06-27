(head,req) ->
  mustache = require("vendor/couchapp/lib/mustache")
  ddoc = this
  view = req.path[req.path.length-1]
  doc = {players: []}
  
  start { "headers": {"Content-Type": "text/html"}}
  
  playerSort = (x,y) ->
    if x.ppg < y.ppg
      return 1
    if y.ppg < x.ppg
      return -1
  
  render = () ->
    doc.players = doc.players.sort(playerSort)
    mustache.to_html(ddoc.templates.individualstandings,doc)
  
  format = (row,nameIdx,teamIdx) ->
    row.value.name = row.key[nameIdx]
    row.value.team = row.key[teamIdx]
    row.value.ppth = row.value.ppth.toFixed 2
    row.value
  
  overall = () ->
    while row = getRow()
      doc.players.push format(row,2,1)
    
    render()
      
  
  switch view
    when "individual_standings"
     overall()