(doc,req) ->
  mustache = require("vendor/couchapp/lib/mustache")
  ddoc = this
  
  if (doc)
    doc._root = "../.."
 
    # gonna make a dangerous assumption here that if teamA doesn't have a TUH value, the round hasn't been entered
    if !doc.teamAtuh
      doc.teamAtuh = 20
      doc.teamBtuh = 20

    for player,i in doc.teamAstats
      player.idx = i

    for player,i in doc.teamBstats
	    player.idx = i
  else
    doc = {}
    doc._root = ".."
  
  return mustache.to_html(ddoc.templates.entry,doc)