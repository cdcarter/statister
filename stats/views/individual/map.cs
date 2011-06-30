(doc) ->
  if doc.type=="game" && doc.teamAtuh && doc.teamBtuh
    for player in doc.teamAstats
      pts = ((player.tens*10)-(player.negs*5))
      ppth = pts/player.tuh
      emit([doc.bracket,doc.teamA,player.name],{
        gp:1, tens:player.tens, ppth:ppth, 
        negs:player.negs, tuh:player.tuh, pts:pts, opponent:doc.teamB})

    for player in doc.teamBstats
      pts = ((player.tens*10)-(player.negs*5))
      ppth = pts/player.tuh
      emit([doc.bracket,doc.teamB,player.name],{
        gp:1, tens:player.tens, ppth:ppth,
        negs:player.negs, tuh:player.tuh, pts:pts, opponent:doc.teamA})