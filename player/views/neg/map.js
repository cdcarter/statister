function(doc) {
	if(doc.type=="game"){
  for(var p in doc.teamAstats) {
    emit([doc.teamA,doc.teamAstats[p].name], doc.teamAstats[p].neg)
  }

  for(var b in doc.teamBstats) {
    emit([doc.teamB,doc.teamBstats[b].name], doc.teamBstats[b].neg)
  }}
}