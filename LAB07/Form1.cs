using System;
using System.Drawing;
using System.Windows.Forms;

namespace LAB07
{
    public partial class Form1 : Form
    {
        // ListBox — список элементов управления и диалогов (левая часть интерфейса)
        private ListBox listBox;

        // root — основной контейнер, делит форму на 2 части (меню + контент)
        private TableLayoutPanel root;

        // header — заголовок справа, показывает выбранный пункт
        private Label header;

        // content — контейнер для динамического размещения элементов
        private TableLayoutPanel content;

        // timer — используется в заданиях (например, часы или ProgressBar)
        private System.Windows.Forms.Timer timer;

        // Цвета темы интерфейса (тёмная тема)
        // Общий Цвет Фона
        private Color bg = Color.FromArgb(43, 43, 43);

        // Цвет правой панели
        private Color panelBg = Color.FromArgb(60, 63, 65);

        // Цвет Шрифта
        private Color fg = Color.FromArgb(169, 183, 198);

        // =========================
        // Задание 1: Конструктор формы
        // =========================
        public Form1()
        {
            // TODO:
            // 1. Установить заголовок формы (Text) "Лабораторная 7"
            this.Text = "Лабораторная 7";

            // 2. Задать размеры формы (Size) 1000x600
            this.Size = new Size(1000, 600);

            // 3. Установить шрифт (Font) JetBrains Mono NL, 20
            this.Font = new Font("JetBrains Mono NL", 10);

            // 4. Применить цвета (BackColor, ForeColor) bg, fg
            this.BackColor = bg;
            this.ForeColor = fg;

            // 5. Создать/инициализировать TableLayoutPanel (root)
            root = new TableLayoutPanel();

            // 6. Dock = Fill
            root.Dock = DockStyle.Fill;

            // 7. Настроить 2 (ColumnCount) колонки ColumnStyles.Add
            // (фиксированная SizeType.Absolute (размер 300) + растягиваемая SizeType.Percent(100%))
            root.ColumnCount = 2;
            root.ColumnStyles.Clear();
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300));
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // 8. Добавить root в Controls (this.Controls.Add())
            this.Controls.Add(root);

            // 9. Вызвать InitListBox()
            InitListBox();

            // 10. Вызвать InitRightPanel()
            InitRightPanel();
        }


        // =========================
        // Задание 2: Инициализация ListBox
        // =========================
        private void InitListBox()
        {
            // TODO:
            // 1. Создать/инициализировать ListBox (listbox)
            listBox = new ListBox();

            // 2. Dock = Fill
            listBox.Dock = DockStyle.Fill;

            // 3. Настроить цвета (фон = panelBg, текст = fg)
            listBox.BackColor = panelBg;
            listBox.ForeColor = fg;

            // 4. Убрать рамку (BorderStyle = None)
            listBox.BorderStyle = BorderStyle.None;

            // 5. Добавить элементы списка Items.AddRange(new string[]{}) (строго в таком порядке):
            //    "DateTimePicker"
            //    "NumericUpDown"
            //    "PictureBox"
            //    "TrackBar"
            //    "Timer"
            //    "ProgressBar"
            //    "ComboBox"
            //    "MessageBox"
            //    "ColorDialog"
            //    "OpenFileDialog"
            //    "FontDialog"
            //    "Немодальное окно"
            listBox.Items.AddRange(new string[]
            {
                "DateTimePicker",
                "NumericUpDown",
                "PictureBox",
                "TrackBar",
                "Timer",
                "ProgressBar",
                "ComboBox",
                "MessageBox",
                "ColorDialog",
                "OpenFileDialog",
                "FontDialog",
                "Немодальное окно"
            });

            // 6. Подписаться на событие SelectedIndexChanged +=
            //    (обработчик: OnSelect)
            listBox.SelectedIndexChanged += OnSelect;

            // 7. Добавить ListBox в root (root.Controls.Add(..., 0, 0)):
            //    - колонка 0, строка 0 (левая часть интерфейса)
            root.Controls.Add(listBox, 0, 0);
        }

        // =========================
        // Задание 3: Правая панель (заголовок + контент)
        // =========================
        private void InitRightPanel()
        {
            // TODO:
            // 1. Создать TableLayoutPanel right (правая часть)
            TableLayoutPanel right = new TableLayoutPanel();

            // 2. Dock = Fill (растянуть на все занимаемое место)
            right.Dock = DockStyle.Fill;

            // 3. Разделить на 2 строки (RowCount = 2)
            right.RowCount = 2;

            // 4. Настроить строки RowStyles.Add
            // (фиксированная SizeType.Absolute (размер 60) + растягиваемая SizeType.Percent(100%))
            right.RowStyles.Clear();
            right.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            right.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // 5. Создать/инициализировать Label (header)
            header = new Label();

            // 6. Настроить выравнивание и отступы (Dock(Fill), Padding(10), TextAlign(ContentAlignment.MiddleLeft))
            header.Dock = DockStyle.Fill;
            header.Padding = new Padding(10);
            header.TextAlign = ContentAlignment.MiddleLeft;
            header.BackColor = panelBg;
            header.ForeColor = fg;
            header.Font = new Font("JetBrains Mono NL", 12, FontStyle.Bold);
            header.Text = "Выберите элемент из списка";

            // 7. Создать/инициализировать TableLayoutPanel (content)
            content = new TableLayoutPanel();

            // 8. Включить прокрутку AutoScroll(true), Dock (Fill), Padding(20), BackColor(panelBg)
            content.AutoScroll = true;
            content.Dock = DockStyle.Fill;
            content.Padding = new Padding(20);
            content.BackColor = panelBg;
            content.RowCount = 0;
            content.ColumnCount = 1;
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // 9. Добавить header и content в right (right.Controls.Add(...))
            right.Controls.Add(header, 0, 0);
            right.Controls.Add(content, 0, 1);

            // 10. Добавить right в root (правая колонка) 1, 0 (root.Controls.Add(..., 1, 0))
            root.Controls.Add(right, 1, 0);
        }

        // =========================
        // Задание 4: Заголовок
        // =========================
        private void SetHeader(string text)
        {
            // TODO:
            // 1. Установить текст header: (header.Text)
            //    "Демонстрация работы: " + text
            header.Text = "Демонстрация работы: " + text;
        }

        // =========================
        // Задание 5: Очистка панели
        // =========================
        private void Clear()
        {
            // TODO:
            // 1. Очистить  content.Controls.Clear()
            content.Controls.Clear();

            // 2. Очистить RowStyles (content.RowStyles.Clear())
            content.RowStyles.Clear();

            // 3. Сбросить RowCount (0) content.RowCount
            content.RowCount = 0;

            // 4. Остановить timer (если используется)
            // если timer != null, Stop()
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }
        }

        // =========================
        // Готовый метод (использовать)
        // =========================
        private void AddControl(Control c)
        {
            c.Dock = DockStyle.Top;
            c.Margin = new Padding(0, 0, 0, 15);
            c.BackColor = panelBg;
            c.ForeColor = fg;

            content.RowCount++;
            content.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            content.Controls.Add(c, 0, content.RowCount - 1);
        }

        // =========================
        // Задание 6: Обработка выбора
        // =========================
        private void OnSelect(object sender, EventArgs e)
        {
            // TODO:
            // 1. Вызвать Clear()
            Clear();

            // 2. Получить выбранный элемент из listBox (SelectedItem) и сохранить в переменную string selected 
            if (listBox.SelectedItem == null) return;
            string selected = listBox.SelectedItem.ToString();

            // 3. Установить заголовок через SetHeader(selected)
            SetHeader(selected);

            // 4. Через switch (listBox.SelectedIndex) вызвать нужный метод
            switch (listBox.SelectedIndex)
            {
             

                
                case 1: NumericDemo(); break;
                case 3: TrackDemo(); break;
                case 5: ProgressDemo(); break;
                case 7: MessageDemo(); break;
                case 9: FileDemo(); break;
                case 11: NonModalDemo(); break;
            }
        }

        // =========================
        // Задание 7: DateTimePicker
        // =========================
        private void DateTimeDemo()
        {
            // TODO:
            // 1. Создать DateTimePicker dt
            // 2. Создать Label lb (Autosize = True)
            // 3. Обработать событие ValueChanged с помощью лямбда-выражения (s, e) =>
            // 4. Выводить дату в lb (dt.Value.ToLongDateString();)
            // 5. Добавить dt, lb через AddControl()

            // Example:
            // При выборе даты в DateTimePicker,
            // в Label отображается:
            // "Понедельник, 1 января 2026 г."
        }

        // =========================
        // Задание 8: NumericUpDown
        // =========================
        private void NumericDemo()
        {
            // TODO:
            // 1. Создать NumericUpDown num
            NumericUpDown num = new NumericUpDown();

            // 2. Задать диапазон (например 0–100) Minumum, Maximum
            num.Minimum = 0;
            num.Maximum = 100;
            num.Value = 50;
            num.Width = 200;

            // 3. Создать Label lb (Autosize=True)
            Label lb = new Label();
            lb.AutoSize = true;
            lb.Text = "Значение: 50";

            // 4. Обработать ValueChanged для num с помощью лямбда-выражения (s, e) =>
            // 5. Выводить num.Value в lb
            num.ValueChanged += (s, e) =>
            {
                lb.Text = "Значение: " + num.Value;
            };

            // 5. Добавить num, label через AddControl()
            AddControl(num);
            AddControl(lb);

            // Example:
            // Пользователь увеличивает значение до 42
            // Label показывает:
            // "Значение: 42"
        }


        // =========================
        // Задание 9: PictureBox
        // =========================
        private void PictureDemo()
        {
            // TODO:
            // 1. Создать PictureBox pb
            // 2. Настроить SizeMode (Zoom)
            // 3. Натроить BorderStyle (BorderStyle.FixedSingle)
            // 4. Создать кнопку load (AutoSize = true, Text="Загрузить")
            // 5. Обработать нажатие на кнопку Click с помощью лямбда-выражения (s, e) =>
            // 6. Использовать/создать OpenFileDialog dlg 
            // 7. Загрузить изображение pb.Image = Image.FromFile(dlg.FileName)
            // если dlg.ShowDialog() == DialogResult.OK
            // 8. Добавить pb, load через AddControl()

            // Example:
            // Пользователь выбирает файл "cat.jpg"
            // В PictureBox отображается изображение кота
        }

        // =========================
        // Задание 10: TrackBar
        // =========================
        private void TrackDemo()
        {
            // TODO:
            // 1. Создать TrackBar track
            TrackBar track = new TrackBar();

            // 2. Создать Label label (AutoSize=True)
            Label label = new Label();
            label.AutoSize = true;
            label.Text = "Значение: 50";

            // 3. Обработать Scroll для label с помощью лямбда-выражения (s, e) =>
            // 4. Выводить значение track.Value в label
            track.Minimum = 0;
            track.Maximum = 100;
            track.Value = 50;
            track.TickFrequency = 10;
            track.Width = 400;

            track.Scroll += (s, e) =>
            {
                label.Text = "Значение: " + track.Value;
            };

            // 5. Добавить track, label через AddControl()
            AddControl(track);
            AddControl(label);

            // Example:
            // Пользователь передвигает ползунок на 75
            // Label показывает:
            // "Значение: 75"
        }

        // =========================
        // Задание 11: Timer
        // =========================
        private void TimerDemo()
        {
            // TODO:
            // 1. Создать Label label (AutoSize=True)
            // 2. Создать Timer timer
            // 3. Задать Интервал (Interval) = 1000
            // 4. Обработать Tick для timer с помощью лямбда-выражения (s, e) =>
            // 5. Изменить текст label на DateTime.Now.ToLongTimeString()
            // 6. Запустить timer (Start())
            // 7. Добавить label через AddControl()

            // Example:
            // Каждую секунду обновляется время:
            // "14:23:01"
            // "14:23:02"
            // "14:23:03"
        }

        // =========================
        // Задание 12: ProgressBar
        // =========================
        private void ProgressDemo()
        {
            // TODO:
            // 1. Создать ProgressBar bar
            ProgressBar bar = new ProgressBar();

            // 2. Создать кнопку Button start (AutoSize = true, Text = "Старт")
            Button start = new Button();
            start.AutoSize = true;
            start.Text = "Старт";

            // 3. Создать Timer timer (Interval=100)
            System.Windows.Forms.Timer progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = 50;

            // 4. Обработать Tick для timer с помощью лямбда-выражения (s, e) =>
            // 5. Если bar.Value < 100, увеличить bar.Value на 1
            // иначе остановить Timer (stop)
            progressTimer.Tick += (s, e) =>
            {
                if (bar.Value < 100)
                {
                    bar.Value += 1;
                }
                else
                {
                    progressTimer.Stop();
                }
            };

            // 6. Обработать нажатие на кнопку start Click с помощью лямбда-выражения (s, e) =>
            // bar.Value задать равным 0, стартовать timer
            start.Click += (s, e) =>
            {
                bar.Value = 0;
                progressTimer.Start();
            };

            // 7. Добавить bar, start через AddControl()
            bar.Width = 400;
            bar.Height = 30;
            bar.Minimum = 0;
            bar.Maximum = 100;
            bar.Value = 0;

            AddControl(bar);
            AddControl(start);

            // Example:
            // После нажатия кнопки:
            // ProgressBar постепенно заполняется от 0 до 100%
        }


        // =========================
        // Задание 13: ComboBox
        // =========================
        private void ComboDemo()
        {
            // TODO:
            // 1. Создать ComboBox combo
            // 2. Добавить элементы в combo Items.AddRange(как в задании 2) (например: Красный, Зелёный, Синий)
            // 3. Создать Label label (Autosize=True)
            // 4. Обработать выбор SelectedItemChanged для combo с помощью лямбда-выражения (s, e) =>
            // изменить текст label на combo.SelectedItem.ToString()
            // 5. Добавить combo, label через AddControl()

            // Example:
            // Пользователь выбирает "Зелёный"
            // Label показывает:
            // "Выбор: Зелёный"
        }

        // =========================
        // Задание 14: MessageBox
        // =========================
        private void MessageDemo()
        {
            // TODO:
            // 1. Создать кнопку show (AutoSize = true)
            Button show = new Button();
            show.AutoSize = true;
            show.Text = "Показать MessageBox";

            // 2. Обработать нажатие на кнопку show Click с помощью лямбда-выражения (s, e) =>
            // 3. Показать MessageBox.Show с текстом "Пример Модального Окна"
            show.Click += (s, e) =>
            {
                DialogResult result = MessageBox.Show(
                    "Пример модального диалогового окна.",
                    "Модальное окно - MessageBox",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    MessageBox.Show("Вы нажали OK!", "Результат");
                }
                else
                {
                    MessageBox.Show("Вы нажали Cancel!", "Результат");
                }
            };

            // 4. Добавить show через AddControl()
            AddControl(show);
        }


        // =========================
        // Задание 15: ColorDialog
        // =========================
        private void ColorDemo()
        {
            // TODO:
            // 1. Создать кнопку Button color (AutoSize = true, Text="Выбрать Цвет")
            // 2. Обработать нажатие на кнопку color Click с помощью лямбда-выражения (s, e) =>
            // 3. Открыть/создать ColorDialog dlg
            // 4. Изменить цвет панели content.BackColor = dlg.Color, если dlg.ShowDialog() == DialogResult.OK 
            // 5. Добавить color через AddControl()

            // Example:
            // Пользователь выбирает синий цвет
            // Фон панели меняется на синий
        }

        // =========================
        // Задание 16: OpenFileDialog
        // =========================
        private void FileDemo()
        {
            // TODO:
            // 1. Создать кнопку Button file (AutoSize = true, Text="Открыть Файл")
            Button file = new Button();
            file.AutoSize = true;
            file.Text = "Открыть файл";

            // 2. Обработать нажатие на кнопку file Click с помощью лямбда-выражения (s, e) =>
            // 3. Открыть/создать OpenFileDialog dlg
            // 4. Показать MessageBox с текстом dlg.FileName, если dlg.ShowDialog() == DialogResult.OK 
            file.Click += (s, e) =>
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
                dlg.Title = "Выберите файл";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Путь к выбранному файлу:\n" + dlg.FileName, "Путь к файлу");
                }
            };

            // 5. Добавить file через AddControl()
            AddControl(file);

            // Example:
            // Пользователь выбирает файл:
            // "C:\\Users\\User\\file.txt"
            // Путь отображается в MessageBox
        }

        // =========================
        // Задание 17: FontDialog
        // =========================
        private void FontDemo()
        {
            // TODO:
            // 1. Создать кнопку Button font (AutoSize = true, Text="Выбрать Шрифт")
            // 2. Обработать нажатие на кнопку font Click с помощью лямбда-выражения (s, e) =>
            // 3. Открыть/создать FontDialog dlg
            // 4. Создать Label label (Autosize=True, Text="Текст", Font=dlg.Font) и добавить через AddControl(), если dlg.ShowDialog() == DialogResult.OK 
            // 5. Добавить file через AddControl()

            // Example:
            // Пользователь выбирает шрифт Arial, 18pt
            // Текст Label меняется на выбранный стиль
        }

        // =========================
        // Задание 18: Немодальное окно
        // =========================
        private void NonModalDemo()
        {
            // TODO:
            // 1. Создать кнопку Button form (AutoSize = true, Text="Выбрать Шрифт")
            Button form = new Button();
            form.AutoSize = true;
            form.Text = "Открыть немодальное окно";

            // 2. Обработать нажатие на кнопку form Click с помощью лямбда-выражения (s, e) =>
            // 3. Создать новую форму Form f (Text="Немодальное Окно")
            // 4. Показать f (Show())
            form.Click += (s, e) =>
            {
                Form f = new Form();
                f.Text = "Немодальное окно";
                f.Size = new Size(400, 300);
                f.StartPosition = FormStartPosition.CenterParent;
                f.BackColor = panelBg;
                f.ForeColor = fg;

                Label info = new Label();
                info.Text = "Это НЕМОДАЛЬНОЕ окно!\n\nВы можете переключаться\nмежду окнами.";
                info.AutoSize = true;
                info.Location = new Point(50, 50);
                info.ForeColor = fg;
                f.Controls.Add(info);

                f.Show();  // НЕ ShowDialog() - немодальное!
            };

            // 5. Добавить form через AddControl()
            AddControl(form);

            // Example:
            // Открывается новое окно,
            // при этом основное окно остаётся доступным
        }
    }
}

