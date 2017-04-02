package controller.commands;

import dataFolder.FacultyEntity;
import dataFolder.FacultyService;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.sql.SQLException;
import java.util.List;


public class GetFaculties implements Command{
	
	private FacultyService facultyService ;

	public GetFaculties() throws SQLException {
		facultyService = new FacultyService();

	}

	@Override
	public String execute(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		List<FacultyEntity> faculties = facultyService.soutgetAll();
		request.setAttribute("faculties", faculties);
		request.getRequestDispatcher("/WEB-INF/view/FacultyList.jsp");
		return "/WEB-INF/view/FacultyList.jsp";

	}
	
}
