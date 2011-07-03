(head,req)->
  mustache = require("vendor/couchapp/lib/mustache")
  ddoc = this
  
  template = "<tr><td>{{round}}</td><td>{{ppg}}</td><td>{{tuppth}}</td><td>{{ppb}}</td></tr>"
  
  start { "headers": {"Content-Type": "text/html"}}
  
  send("<table>")
  send("<tr><th>Round</th><th>PPG/Team</th><th>TUPts/TUH</th><th>BPts/BHrd</th></tr>")
  
  while row = getRow()
    row.value.round = row.key
    row.value.tuppth = row.value.tuppth.toFixed 2
    row.value.ppg = row.value.ppg.toFixed 2
    row.value.ppb = row.value.ppb.toFixed 2
    send mustache.to_html(template,row.value)
  
  send("</table>")
  
  return ""