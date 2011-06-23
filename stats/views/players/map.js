function(doc) {
	if (doc.type=="game") {
		for (p in doc.teamAstats) {
			emit([doc.teamA,doc.teamAstats[p].name],null)
		}
		for (p in doc.teamBstats) {
			emit([doc.teamB,doc.teamBstats[p].name],null)
		}
	}
}