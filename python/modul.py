# -*- coding: utf-8 -*-
from PIL import Image
import cv2
import pytesseract
import numpy as np


def get_text_of_image(image_name: str, lang: str, mode=2) -> str:
    if mode == 0:
        return str(pytesseract.image_to_string(image=image_name, lang=lang))
    elif mode == 1:
        return str(pytesseract.image_to_string(cv2.threshold(cv2.cvtColor(cv2.imread(image_name), cv2.COLOR_BGR2GRAY), 0, 255, cv2.THRESH_BINARY_INV + cv2.THRESH_OTSU)[1], lang=lang))
    elif mode == 2:
        return str(pytesseract.image_to_string(cv2.imread(image_name), lang=lang))
    elif mode == 3:
        return str(pytesseract.image_to_string(Image.open(image_name), lang=lang))
    elif mode == 4:
        return str(pytesseract.image_to_string(np.array(Image.open(image_name)), lang=lang))


def texted_to_str(texted: str) -> list:
    return [_ for _ in texted.split('\n') if _ not in ['', '\n']]


def letter_is_not_parasha(letter: str) -> bool:
    return letter == letter.lower() and letter not in ['(', ')', '«', '»', '.', ',', ':', ';']


def formate_strs(strs: list) -> str:
    news = [strs[0]]
    for i in range(1, len(strs)):
        if strs[i - 1][-1] == '-':
            news[-1] = news[-1][:-1] + strs[i]
        elif strs[i - 1][-1] == ' ':
            news[-1] += strs[i]
        elif (letter_is_not_parasha(strs[i - 1][-1]) and strs[i][0] == strs[i][0].lower()) or (strs[i - 1][-1] in [')', '»', ','] and letter_is_not_parasha(strs[i][0])):
            news[-1] += ' ' + strs[i]
        else:
            news.append(strs[i])
    return '\n'.join(news).replace('}', ')').replace(']', ')').replace('{', '(').replace('[', '(')
