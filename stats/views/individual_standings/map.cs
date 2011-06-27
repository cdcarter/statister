(doc) ->
  if doc.type=="game" && doc.teamAtuh && doc.teamBtuh
    for player in doc.teamAstats
      pts = ((player.tens*10)-(player.negs*5))
      emit([doc.bracket,doc.teamA,player.name],{gp:1, tens:player.tens, negs:player.negs, tuh:player.tuh, pts:pts})

    for player in doc.teamBstats
      pts = ((player.tens*10)-(player.negs*5))
      emit([doc.bracket,doc.teamB,player.name],{gp:1, tens:player.tens, negs:player.negs, tuh:player.tuh, pts:pts})