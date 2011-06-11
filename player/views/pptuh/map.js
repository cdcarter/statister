function(doc) {
	if(doc.type=="game"){
  for(var p in doc.teamAstats) {
    emit([doc.teamA,doc.teamAstats[p].name],[(doc.teamAstats[p].ten*10)-(doc.teamAstats[p].neg*5),doc.teamAstats[p].tuh])
  }

  for(var b in doc.teamBstats) {
    emit([doc.teamB,doc.teamBstats[b].name],[(doc.teamBstats[b].ten*10)-(doc.teamBstats[b].neg*5),doc.teamBstats[b].tuh])
  }}
}