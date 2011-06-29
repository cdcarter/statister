(doc) ->
  if doc.type == "game"
    entered = (doc.teamAtuh? && doc.teamBtuh?)
    emit([entered,doc.round],null)