(head,req) ->
  mustache = require("vendor/couchapp/lib/mustache")
  ddoc = this
  doc = {bracket: '', teams: []}
  
  start { "headers": {"Content-Type": "text/html"}}
  
  render = () ->
    # sort by win pct and ppg if pct is equal
    doc.teams = doc.teams.sort((x,y) ->
      if x.pct < y.pct
        return 1
      if y.pct < x.pct
        return -1
      if x.pct == y.pct
        if x.ppg < y.ppg
          return 1
        if y.ppg < x.ppg
          return -1
    )
    send(mustache.to_html(ddoc.templates.brackettable,doc))
  
  format = (row) ->
    row.value.name = row.key[1]
    row.value.ppb = row.value.ppb.toFixed 2
    row.value.ppth = row.value.ppth.toFixed 2
    row.value.pct = row.value.pct.toFixed 2
    row.value.mrg = row.value.mrg.toFixed 2
  
  while row = getRow()
    if row.key[0] != doc.bracket
      if doc.bracket != ''
        render()
      doc = {teams: []}
      doc.bracket = row.key[0]
      format(row)
      doc.teams.push row.value
    else
      row.value.name = row.key[1]
      format(row)
      doc.teams.push row.value
  
  render()