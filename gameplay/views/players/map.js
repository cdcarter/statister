function(doc) {
	if (doc.type=="game") {
		for (p in doc.teamAstats) {
			emit([doc._id,doc.teamA,doc.round],doc.teamAstats[p].name)
		}
		for (p in doc.teamBstats) {
			emit([doc._id,doc.teamB,doc.round],doc.teamBstats[p].name)
		}
	}
}