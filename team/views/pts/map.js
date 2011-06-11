function(doc) {
		if(doc.type=="game"){
  emit(doc.teamB,doc.teamBscore)
  emit(doc.teamA,doc.teamAscore)}
}