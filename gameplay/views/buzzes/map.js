function(doc) {
  if (doc.type=="buzz") {
    emit(doc._id, doc);
  }
};