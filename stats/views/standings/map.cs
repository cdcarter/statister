(doc) ->
  if doc.type=="game" and doc.teamAtuh and doc.teamBtuh

    resultA = {
      gp:1,w:0,l:0,pts:doc.teamAscore,ptsa:doc.teamBscore,
      tens:0,negs:0,tuh:doc.teamAtuh,
      bhrd:doc.teamAbhrd, bpts:doc.teamAbpts
    }
    resultB = {
      gp:1,w:0,l:0,pts:doc.teamBscore,ptsa:doc.teamAscore,
      tens:0,negs:0,tuh:doc.teamBtuh,
      bhrd:doc.teamBbhrd, bpts:doc.teamBbpts
    }
    
    if doc.teamAscore > doc.teamBscore
      resultA.w = 1
      resultB.l = 1
    else
      resultA.l = 1
      resultB.w = 1

    for player in doc.teamAstats
      resultA.tens += player.tens
      resultA.negs += player.negs
    
    for player in doc.teamBstats
      resultB.tens += player.tens
      resultB.negs += player.negs
    
    emit [doc.teamA,doc.bracket],resultA 
    emit [doc.teamB,doc.bracket],resultB
