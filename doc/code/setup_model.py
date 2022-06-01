# Set up model
i3d_easy = InceptionI3d(in_channels=NUM_CHANNELS)
i3d_easy.replace_logits(NUM_CLASSES_EASY)
i3d_easy.load_state_dict(torch.load(FILE_MODEL_EASY, map_location=torch.device(DEVICE)))
i3d_easy.eval()