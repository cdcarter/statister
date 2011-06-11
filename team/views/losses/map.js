function(doc) {
		if(doc.type=="game"){
  if(doc.teamAscore > doc.teamBscore) {emit(doc.teamB,1)}else{emit(doc.teamA,1)}}
}