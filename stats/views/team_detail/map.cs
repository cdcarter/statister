(doc) ->
  
  if doc.type == "game" && doc.teamAtuh && doc.teamBtuh
    teamA = {
      tens:0, negs:0, pts: doc.teamAscore, ptsa: doc.teamBscore, opponent: doc.teamB, round: doc.round,
      tuh: doc.teamAtuh, bhrd: doc.teamAbhrd, bpts: doc.teamAbpts, ppth: (doc.teamAscore / doc.teamAtuh),
      ppb: doc.teamAbpts / doc.teamAbhrd
    }
    teamB = {
      tens:0, negs:0, pts: doc.teamBscore, ptsa: doc.teamAscore, opponent: doc.teamA, round: doc.round,
      tuh: doc.teamBtuh, bhrd: doc.teamBbhrd, bpts: doc.teamBbpts, ppth: (doc.teamBscore / doc.teamBtuh),
      ppb: doc.teamBbpts / doc.teamBbhrd
    }
      
    for player in doc.teamAstats
      teamA.tens += player.tens
      teamA.negs += player.negs
      emit([doc.teamA,1],player)
      
    for player in doc.teamBstats
      teamB.tens += player.tens
      teamB.negs += player.negs
      emit([doc.teamB,1],player)
    
    emit([doc.teamA,0],teamA)
    emit([doc.teamB,0],teamB)