(doc) ->
  if doc.type=="game" and doc.teamAtuh and doc.teamBtuh
    # results =  [gp,wins,losses,pts,ptsa,ppg,pct,mrg,tens,negs,tuh,ppth,bhrd,bpts,ppb]
    resultA = [1,0,0,doc.teamAscore,doc.teamBscore,0,0,0,0,0,doc.teamAtuh,0,doc.teamAbhrd,doc.teamAbpts,0]
    resultB = [1,0,0,doc.teamBscore,doc.teamAscore,0,0,0,0,0,doc.teamBtuh,0,doc.teamBbhrd,doc.teamBbpts,0]
    
    if doc.teamAscore > doc.teamBscore
      resultA[1] = 1
      resultB[2] = 1
    else
      resultA[2] = 1
      resultB[1] = 1

    for player in doc.teamAstats
      resultA[8] += player.tens
      resultA[9] += player.negs
    
    for player in doc.teamBstats
      resultB[8] += player.tens
      resultB[9] += player.negs
    
    emit [doc.bracket,doc.teamA],resultA 
    emit [doc.bracket,doc.teamB],resultB
