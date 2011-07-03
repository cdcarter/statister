(head,req) ->
  mustache = require("vendor/couchapp/lib/mustache")
  ddoc = this
  view = req.path[req.path.length-1]
  start { "headers": {"Content-Type": "text/html"}}
  
  render = (team) ->
    team.ppth = (team.pts / team.tuh).toFixed 2
    team.ppb = (team.bpts / team.bhrd).toFixed 2
    
    for player in team.players
      player.ppth = (player.pts / player.tuh).toFixed 2
      player.ppg = (player.pts / player.gp).toFixed 2
    
    send mustache.to_html(ddoc.templates.teamdetail,team)
  
  mainLoop = () ->
    team = {pts:0, pts:0, tens: 0, negs:0, tuh:0, bhrd:0, bpts: 0, name: "", players: [], games: []}
    
    while row=getRow()
      if team.name != row.key[0]
        render(team) unless team.name == ""
        team = {pts:0, pts:0, tens: 0, negs:0, tuh:0, bhrd:0, bpts: 0, name: row.key[0], players: [], games: []}
      
      if row.value.name?
        # is a player
        match = false
        for player,pi in team.players
          if player.name == row.value.name
            match = pi
        
        if match
          player = team.players[match]
          player.tens += row.value.tens
          player.negs += row.value.negs
          player.tuh += row.value.tuh
          player.gp += (player.tuh/20)
          player.pts += (row.value.tens * 10) - (row.value.negs * 5)
        else
          row.value.gp = row.value.tuh/20
          row.value.pts = (row.value.tens * 10) - (row.value.negs * 5)
          team.players.push row.value
          
      if row.value.opponent?
        row.value.ppth = row.value.ppth.toFixed 2
        row.value.ppb = row.value.ppb.toFixed 2
        team.games.push row.value
        team.pts += row.value.pts
        team.ptsa += row.value.ptsa
        team.tens += row.value.tens
        team.negs += row.value.negs
        team.tuh += row.value.tuh
        team.bhrd += row.value.bhrd
        team.bpts += row.value.bpts
    
    render(team)
  
  switch view
    when "team_detail"
      mainLoop()
      
  return ""
        