function(doc) {
		if(doc.type=="game"){
  emit(doc.teamA,doc.teamAscore-doc.teamBscore)
  emit(doc.teamB,doc.teamBscore-doc.teamAscore)}
}