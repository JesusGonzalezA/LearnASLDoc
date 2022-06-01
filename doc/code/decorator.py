# Decorator to check a JWT
def token_required(f):
	@wraps(f)
	def decorated(*args, **kwargs):
		token = None
		if 'x-access-token' in request.headers:
			token = request.headers['x-access-token']
		if not token:
			return jsonify({'message' : 'Token is missing !!'}), 401

		try:
			jwt.decode(token, SECRET_KEY, algorithms=["HS256"])
		except Exception as e:
			return jsonify({
				'message' : 'Token is invalid !!'
			}), 401
		return f(*args, **kwargs)

	return decorated

# Route
@app.route('/validate', methods=['POST'])
@token_required
def validate_video():
    # code