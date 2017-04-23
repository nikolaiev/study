package controller;

import controller.commands.*;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.Map;

/**
 * Servlet implementation class ApiController
 */
//@WebServlet("/rest/*")
public class ApiController extends HttpServlet {
	private static final long serialVersionUID = 1L;

	private Map<String , Command> commands = new HashMap<>();
    /**
     * @see HttpServlet#HttpServlet()
     */
    public ApiController() {
        super();
        // TODO Auto-generated constructor stub
    }

    @Override
    public void init(){
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		//response.getWriter().append("Served at: ").append(request.getContextPath());

		try {
			processRequest(request, response);
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		try {
			processRequest(request , response);
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}
	
	void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException, SQLException {
		String method = request.getMethod().toUpperCase();
		String path = request.getRequestURI();
		path = path.replaceAll(".*/api", "").
				replaceAll("\\d+", "");
		String key = method+":"+path;
		System.out.println(key);


		String viewPage ;
		if(key.equals("GET:/faulty/")){
			viewPage= new GetFaculties().execute(request, response);
		} else {

			Command command = null;// commands.getOrDefault(key, (req, resp) -> "/index.jsp");

			viewPage= command.execute(request, response);
		}

		request.getRequestDispatcher(viewPage)
		       .forward(request, response);
	}

}
