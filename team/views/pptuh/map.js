function(doc) {
		if(doc.type=="game"){
  emit(doc.teamB,[doc.teamBscore,doc.teamBtuh])
  emit(doc.teamA,[doc.teamAscore,doc.teamAtuh])}
}