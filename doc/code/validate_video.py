# Function to validate a video filename
# - It should not be empty
# - It should has a dot
# - The extension should be in 'ALLOWED_EXTENSIONS'
def validate_video_filename(filename):
	if filename == '':
		return False
	if not '.' in filename:
		return False

	extension = filename.rsplit('.', 1)[1]

	return extension.upper() in ALLOWED_EXTENSIONS

@app.route('/validate', methods=['POST'])
@token_required
def validate_video():
    if request.files:
        video = request.files['video']
        if not validate_video_filename(video.filename):
            return jsonify({
                'message': 'Invalid video or empty'
            }), 409

        filename = os.path.join(os.getenv('UPLOAD_FOLDER'), secure_filename(video.filename))
        # Code
    else:
        return jsonify({
            'message': 'You should pass a video'
        }), 409