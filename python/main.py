# -*- coding: utf-8 -*-
from modul import formate_strs, texted_to_str, get_text_of_image
from tkinter import *
from tkinter import filedialog
import threading
import docx
import win32com.client as wrd
from random import randint
from os import listdir
from time import time

bgc = '#060d13'
bright_bgc = '#132639'
btn_bgc = '#264d73'
text_color = '#ecf2f9'

max_mode = 5
mode = 2
viewing = 2
breaking = True
numering = True

def create_frame(var, name, text_name, text, console, width=22, ratio=2, var_type='bool'):
    exec(f"""
{name} = Frame(root, width=window_width)
{name}.pack()
{text_name} = {text}
for i in range({ratio}):
    button = Button({name}, text={text_name}[i],
                    command=lambda it=i: exec(f"global {var}; {var} = {var_type}(it); update_console_output('{console} = ' + str({var_type}(it)))"),
                    width={width},
                    bg=bright_bgc, relief='sunken', bd=3, fg=text_color,
                    font="Times_New_Roman 14")
    button.pack(side=LEFT)
""")


def choose_path():
    return filedialog.askdirectory()


if __name__ == '__main__':
    window_width = 500
    window_height = 650
    root = Tk()
    root.geometry(f"{window_width}x{window_height}")
    root.resizable(False, False)
    root.title("Overseeer_Tk")


    def update_console_output(stroke, color='#ffffff'):
        text_box.tag_configure("custom_tag", foreground=color)
        text_box.insert('end', stroke + '\n', "custom_tag")
        text_box.see("end")


    def scan_all_photos(folder_path, lang='rus', mode=2):
        toki = time()
        data = []
        passed = 0
        for photo in sorted(listdir(folder_path), key=lambda x: float('.'.join(x.split('.')[:-1]))):
            jikan = time() - toki
            update_console_output('-' * 99)
            update_console_output(f'{photo} |   начато  | {jikan}')
            data.append((("-" * 35 + photo + "-" * 35) if numering else '') +
                        formate_strs(texted_to_str(get_text_of_image(folder_path + '\\' + photo, lang, mode))))
            update_console_output(f'{photo} | закончено | {time() - toki}')
            update_console_output('-' * 99)
            update_console_output(f'потраченное время: {time() - toki - jikan}')
            passed += 1
            update_console_output(f"выполнено {passed} / {len(listdir(folder_path))}")
        update_console_output(f'общее время {time() - toki}')
        update_console_output(f'среднее время на фото {(time() - toki) / len(listdir(folder_path))}')
        return folder_path, data, time()


    def write_all_in(folder_path: str, data: list, toki: float):
        global viewing
        name = '\\'.join(folder_path.split('/')[:-1]) + '\\' + f'{folder_path.split("/")[-1]}_{randint(-999999, 0)}.docx'
        if viewing < 2:
            with open(name, 'w'): pass
            word = wrd.Dispatch('Word.Application')
            word.Visible = bool(viewing)
            document = word.Documents.Open(name)

            for page in data:
                for par in page.split('\n'):
                    paragraph = document.Content.Paragraphs.Add()
                    paragraph.Range.Text = par
                    paragraph.Range.InsertParagraphAfter()
                    if viewing:
                        p_r = paragraph.Range
                        word.ActiveWindow.ScrollIntoView(p_r)
                if breaking:
                    selection = word.Selection
                    selection.EndKey(6)
                    selection.InsertBreak(7)
            document.SaveAs(name)
            if not viewing:
                word.Quit()
        else:
            document = docx.Document()
            for layer in data:
                for stroka in layer.split('\n'):
                    document.add_paragraph(stroka)
                document.add_page_break()
            document.save(name)

        update_console_output('-' * 99)
        update_console_output(f'время записи в файл {time() - toki}')
        update_console_output('/' * 124)
        update_console_output(f'ВСЕ ЗАВЕРШЕНО УДАЧНО')
        update_console_output('/' * 124, '#00ff00')


    def scanner():
        try:
            write_all_in(*scan_all_photos(folder_path=choose_path(), lang='rus', mode=mode))
        except Exception as err:
            update_console_output('#' * 55 + '\n' + '#' * 55)
            update_console_output(f'произошла ошибка: {err}')
            update_console_output('#' * 55 + '\n' + '#' * 55, '#ff0000')


    def why():
        thread = threading.Thread(target=scanner)
        thread.daemon = True
        thread.start()

    # directory button
    button = Button(root, text="Выбрпать папку", command=why,
                    width=window_width, height=2,
                    bg=bright_bgc, relief='sunken', bd=3, fg=text_color,
                    font="Times_New_Roman 14")
    button.pack()
    # other buttons in frames
    create_frame('mode', 'button_m_frame', 'text_in_m',
                 range(max_mode), 'режим сканирования', 8, max_mode, 'int')
    create_frame('viewing', 'button_v_frame', 'text_in_v',
                 ['не видимый ворд', 'видимый', 'другое'],  'запись в ворд', 14, 3, 'int')
    create_frame('breaking', 'button_b_frame', 'text_in_b',
                 ['без разрыва страницы', 'разрыв страницы'], 'разрыв страницы')
    create_frame('numering', 'button_n_frame', 'text_in_n',
                 ['без преднумерации', 'преднумерация страниц'], 'преднумерация страниц')
    # texts
    text_box = Text(root, relief='sunken', bg=bgc, fg=text_color, height=window_height, font="Times_New_Roman 12")
    text_box.pack()
    # pre-console
    update_console_output(f'режим сканирования = {mode}')
    update_console_output(f'запись в ворд = {viewing}')
    update_console_output(f'разрыв страницы = {breaking}')
    update_console_output(f'преднумерация страниц = {numering}')
    root.mainloop()
