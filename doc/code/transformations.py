video = cv2.VideoCapture(filename)

# Transform video
start_f = 0
num_frames = int(video.get(cv2.CAP_PROP_FRAME_COUNT))
rgb_frames = utils.load_rgb_frames_from_video(video, start_f, num_frames)
padded_frames = utils.pad(rgb_frames, num_frames)
crop_transformations = transforms.Compose([videotransforms.CenterCrop(224)])
transformed_video_as_images = crop_transformations(padded_frames)