DOC := proyecto.tex

all: doc

doc: $(DOC:.tex=.pdf)

clean:
	rm proyecto.aux proyecto.bbl proyecto.blg proyecto.lof proyecto.log proyecto.lot  proyecto.out proyecto.toc proyecto.pdf

all: proyecto.pdf

%.pdf: %.tex
	pdflatex $< && bibtex $* && pdflatex $< && pdflatex $<



