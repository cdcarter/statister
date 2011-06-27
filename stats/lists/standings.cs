(head,req) ->
  mustache = require("vendor/couchapp/lib/mustache")
  ddoc = this
  view = req.path[req.path.length-1]
  doc = {bracket: '', teams: []}
  
  start { "headers": {"Content-Type": "text/html"}}
  
  team_sort =(x,y) ->
    if x.pct < y.pct
      return 1
    if y.pct < x.pct
      return -1
    if x.pct == y.pct
      if x.ppg < y.ppg
        return 1
      if y.ppg < x.ppg
        return -1
  
  render = () ->
    # sort by win pct and ppg if pct is equal
    doc.teams = doc.teams.sort(team_sort)
    send(mustache.to_html(ddoc.templates.brackettable,doc))
  
  format = (row,nameIdx) ->
    row.value.name = row.key[nameIdx]
    row.value.ppb = row.value.ppb.toFixed 2
    row.value.ppth = row.value.ppth.toFixed 2
    row.value.pct = row.value.pct.toFixed 2
    row.value.mrg = row.value.mrg.toFixed 2
  
  byBracket = () ->
    while row = getRow()
      if row.key[0] != doc.bracket
        if doc.bracket != ''
          render()
        doc = {teams: []}
        doc.bracket = row.key[0]
        format(row,1)
        doc.teams.push row.value
      else
        row.value.name = row.key[1]
        format(row,1)
        doc.teams.push row.value
    
    render()
    
  overall =() ->
    while row = getRow()
      format(row,0)
      doc.teams.push row.value
    
    render()
    
  switch view
    when "standings_by_bracket"
      byBracket()
    when "standings"
      overall()
    else
      send("<p>That view is not supported by this list function</p>")
      