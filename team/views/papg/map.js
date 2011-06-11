function(doc) {
		if(doc.type=="game"){
  emit(doc.teamA,doc.teamBscore)
  emit(doc.teamB,doc.teamAscore)}
}