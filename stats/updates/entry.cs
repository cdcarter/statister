(doc,req) ->
  mustache = require("vendor/couchapp/lib/mustache")
  ddoc = this;
  	
  doc.moderator = req.form.moderator
  
  doc.teamAscore = (Number req.form.teamAscore)
  doc.teamBscore = (Number req.form.teamBscore)
  
  doc.teamAtuh = (Number req.form.teamAtuh)
  doc.teamBtuh = (Number req.form.teamBtuh)
  
  doc.teamAbhrd = (Number req.form.teamAbhrd)
  doc.teamBbhrd = (Number req.form.teamBbhrd)
  
  doc.teamAbpts = (Number req.form.teamAbpts)
  doc.teamBbpts = (Number req.form.teamBbpts)

  for player,i in doc.teamAstats
    player.tens = (Number req.form["teamA#{i}tens"])
    player.negs = (Number req.form["teamA#{i}negs"])
    player.tuh = (Number req.form["teamA#{i}tuh"])
  
  for player,i in doc.teamBstats
    player.tens = (Number req.form["teamA#{i}tens"])
    player.negs = (Number req.form["teamA#{i}negs"])
    player.tuh = (Number req.form["teamA#{i}tuh"])

  
  resp = "<html><title>redirect</title><body><a href='../../_show/game_entry/#{doc._id}'>Click Here</a><br>
  <a href='../../_list/games/games_by_bracket'>Game List</a></body></html>"
  
  [doc,resp]