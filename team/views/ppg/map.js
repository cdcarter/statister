function(doc) {
		if(doc.type=="game"){
  emit(doc.teamA,doc.teamAscore)
  emit(doc.teamB,doc.teamBscore)}
}