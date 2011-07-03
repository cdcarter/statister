(doc) ->
  if doc.type == "game" and doc.teamAtuh? and doc.teamBtuh?
    teamA = {pts: doc.teamAscore, tpts:0, tuh: doc.teamAtuh, bpts: doc.teamAbpts, bhrd: doc.teamAbhrd, gp:1}
    teamB = {pts: doc.teamBscore, tpts:0, tuh: doc.teamBtuh, bpts: doc.teamBbpts, bhrd: doc.teamBbhrd, gp:1}
    
    for player in doc.teamAstats
      teamA.tpts += (player.tens * 10) - (player.negs * 5)
    for player in doc.teamBstats
      teamB.tpts += (player.tens * 10) - (player.negs * 5)
      
    emit(doc.round,teamA)
    emit(doc.round,teamB)